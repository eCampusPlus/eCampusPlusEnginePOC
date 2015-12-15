using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eCampusPlusPlateforme.Startup))]
namespace eCampusPlusPlateforme
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
