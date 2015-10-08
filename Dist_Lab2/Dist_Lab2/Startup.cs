using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dist_Lab2.Startup))]
namespace Dist_Lab2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
