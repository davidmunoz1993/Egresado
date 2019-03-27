using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Egresados.Startup))]
namespace Egresados
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
