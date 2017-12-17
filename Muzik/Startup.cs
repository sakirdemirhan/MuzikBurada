using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Muzik.Startup))]
namespace Muzik
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
