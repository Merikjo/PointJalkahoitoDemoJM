using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PointJalkahoitoDemoJM.Startup))]
namespace PointJalkahoitoDemoJM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
