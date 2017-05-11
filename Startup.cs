using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ErieHack_TeamEdgwater.Startup))]
namespace ErieHack_TeamEdgwater
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
