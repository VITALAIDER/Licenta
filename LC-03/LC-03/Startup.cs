using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LC_03.Startup))]
namespace LC_03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
