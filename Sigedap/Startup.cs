using Microsoft.Owin;
using Owin;
using Sigedap.Helpers;

[assembly: OwinStartupAttribute(typeof(Sigedap.Startup))]
namespace Sigedap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
