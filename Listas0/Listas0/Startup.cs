using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Listas0.Startup))]
namespace Listas0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
