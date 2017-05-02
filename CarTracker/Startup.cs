using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarTracker.Startup))]
namespace CarTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
