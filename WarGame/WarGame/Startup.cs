using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WarGame.Startup))]
namespace WarGame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
