using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Merachel.Startup))]
namespace Merachel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
