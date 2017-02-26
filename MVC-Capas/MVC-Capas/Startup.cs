using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Capas.Startup))]
namespace MVC_Capas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
