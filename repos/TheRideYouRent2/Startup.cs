using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheRideYouRent2.Startup))]
namespace TheRideYouRent2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
