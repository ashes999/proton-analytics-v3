using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProtonAnalytics.Web.Startup))]
namespace ProtonAnalytics.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
