using Microsoft.Owin;
using Owin;
using TravelAgency.BLL.Configs;

[assembly: OwinStartupAttribute(typeof(TravelAgency.WEB.Startup))]
namespace TravelAgency.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.ConfigureAuth();
        }
    }
}
