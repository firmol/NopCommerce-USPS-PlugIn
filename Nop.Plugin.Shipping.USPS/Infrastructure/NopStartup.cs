using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;

namespace Nop.Plugin.Shipping.USPS.Infrastructure
{
    public class NopStartup : INopStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // IHttpClientFactory and IMemoryCache are already provided by NopCommerce core.
        }

        public void Configure(IApplicationBuilder application)
        {
        }

        public int Order => 101;
    }
}
