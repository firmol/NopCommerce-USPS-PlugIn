using System.Collections.Generic;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Shipping.USPS.Models
{
    public class USPSShippingModel : BaseNopModel
    {
        public USPSShippingModel()
        {
            AvailableCarrierServicesDomestic    = new List<string>();
            CarrierServicesOfferedDomestic      = new List<string>();
            AvailableCarrierServicesInternational  = new List<string>();
            CarrierServicesOfferedInternational    = new List<string>();
        }

        [NopResourceDisplayName("Plugins.Shipping.USPS.Fields.ClientId")]
        public string ClientId { get; set; }

        [NopResourceDisplayName("Plugins.Shipping.USPS.Fields.ClientSecret")]
        public string ClientSecret { get; set; }

        /// <summary>True when a ClientSecret is already saved in settings (used to show placeholder in view)</summary>
        public bool HasClientSecret { get; set; }

        [NopResourceDisplayName("Plugins.Shipping.USPS.Fields.UseSandbox")]
        public bool UseSandbox { get; set; }

        [NopResourceDisplayName("Plugins.Shipping.USPS.Fields.AdditionalHandlingCharge")]
        public decimal AdditionalHandlingCharge { get; set; }

        [NopResourceDisplayName("Plugins.Shipping.USPS.Fields.AvailableCarrierServicesDomestic")]
        public IList<string> AvailableCarrierServicesDomestic { get; set; }

        /// <summary>Mail class codes of currently selected domestic services</summary>
        public IList<string> CarrierServicesOfferedDomestic { get; set; }

        /// <summary>Values submitted from checkboxes (mail class codes)</summary>
        public string[] CheckedCarrierServicesDomestic { get; set; }

        [NopResourceDisplayName("Plugins.Shipping.USPS.Fields.AvailableCarrierServicesInternational")]
        public IList<string> AvailableCarrierServicesInternational { get; set; }

        /// <summary>Mail class codes of currently selected international services</summary>
        public IList<string> CarrierServicesOfferedInternational { get; set; }

        /// <summary>Values submitted from checkboxes (mail class codes)</summary>
        public string[] CheckedCarrierServicesInternational { get; set; }
    }
}
