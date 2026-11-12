using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Almisbah_library.Startup))]
namespace Almisbah_library
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
