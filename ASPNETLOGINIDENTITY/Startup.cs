using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNETLOGINIDENTITY.Startup))]
namespace ASPNETLOGINIDENTITY
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
