using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CafeteriaAhoraSiEsteEsElBueno.Startup))]
namespace CafeteriaAhoraSiEsteEsElBueno
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
