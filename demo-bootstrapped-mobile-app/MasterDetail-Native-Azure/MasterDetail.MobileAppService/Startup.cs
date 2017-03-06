using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MasterDetail.MobileAppService.Startup))]

namespace MasterDetail.MobileAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}