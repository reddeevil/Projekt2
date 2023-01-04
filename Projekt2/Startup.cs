using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Projekt2.Startup))]
namespace Projekt2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
