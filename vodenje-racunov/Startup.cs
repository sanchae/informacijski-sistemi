using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(vodenje_racunov.Startup))]
namespace vodenje_racunov
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
