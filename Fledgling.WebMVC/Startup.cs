using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fledgling.WebMVC.Startup))]
namespace Fledgling.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
