using FridgeDate.Web.App_Start;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FridgeDate.Web.Startup))]
namespace FridgeDate.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            UnityConfig.RegisterTypes(UnityConfig.GetConfiguredContainer());
        }
    }
}
