using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Shipping.USPS.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Shipping.USPS.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class ShippingUSPSController : BasePluginController
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly USPSSettings _uspsSettings;

        #endregion

        #region Ctor

        public ShippingUSPSController(
            ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            ISettingService settingService,
            USPSSettings uspsSettings)
        {
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _settingService = settingService;
            _uspsSettings = uspsSettings;
        }

        #endregion

        #region Methods

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageShippingSettings))
                return AccessDeniedView();

            var model = new USPSShippingModel
            {
                ClientId                 = _uspsSettings.ClientId,
                ClientSecret             = string.Empty, // never send the secret back to the browser
                HasClientSecret          = !string.IsNullOrEmpty(_uspsSettings.ClientSecret),
                UseSandbox               = _uspsSettings.UseSandbox,
                AdditionalHandlingCharge = _uspsSettings.AdditionalHandlingCharge
            };

            var offeredDomestic = _uspsSettings.CarrierServicesOfferedDomestic ?? string.Empty;
            foreach (var mailClass in USPSShippingDefaults.DomesticMailClasses)
            {
                model.AvailableCarrierServicesDomestic.Add(USPSShippingDefaults.GetDomesticDisplayName(mailClass));
                if (offeredDomestic.Contains($"[{mailClass}]"))
                    model.CarrierServicesOfferedDomestic.Add(mailClass);
            }

            var offeredIntl = _uspsSettings.CarrierServicesOfferedInternational ?? string.Empty;
            foreach (var mailClass in USPSShippingDefaults.InternationalMailClasses)
            {
                model.AvailableCarrierServicesInternational.Add(USPSShippingDefaults.GetInternationalDisplayName(mailClass));
                if (offeredIntl.Contains($"[{mailClass}]"))
                    model.CarrierServicesOfferedInternational.Add(mailClass);
            }

            return View("~/Plugins/Shipping.USPS/Views/Configure.cshtml", model);
        }

        [HttpPost]
        [AdminAntiForgery]
        public IActionResult Configure(USPSShippingModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageShippingSettings))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return Configure();

            _uspsSettings.ClientId                = model.ClientId;
            // Only overwrite the secret when a new value was explicitly submitted
            if (!string.IsNullOrWhiteSpace(model.ClientSecret))
                _uspsSettings.ClientSecret = model.ClientSecret;
            _uspsSettings.UseSandbox              = model.UseSandbox;
            _uspsSettings.AdditionalHandlingCharge = model.AdditionalHandlingCharge;

            var domesticSb = new StringBuilder();
            if (model.CheckedCarrierServicesDomestic?.Any() ?? false)
                foreach (var code in model.CheckedCarrierServicesDomestic)
                    domesticSb.Append($"[{code}]:");
            else
                domesticSb.Append("[PRIORITY_MAIL]:[USPS_GROUND_ADVANTAGE]:[PRIORITY_MAIL_EXPRESS]:");
            _uspsSettings.CarrierServicesOfferedDomestic = domesticSb.ToString();

            var intlSb = new StringBuilder();
            if (model.CheckedCarrierServicesInternational?.Any() ?? false)
                foreach (var code in model.CheckedCarrierServicesInternational)
                    intlSb.Append($"[{code}]:");
            else
                intlSb.Append("[PRIORITY_MAIL_INTERNATIONAL]:[PRIORITY_MAIL_EXPRESS_INTERNATIONAL]:");
            _uspsSettings.CarrierServicesOfferedInternational = intlSb.ToString();

            _settingService.SaveSetting(_uspsSettings);

            _notificationService.SuccessNotification(
                _localizationService.GetResource("Admin.Plugins.Saved"));

            return Configure();
        }

        #endregion
    }
}
