using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Manateq.Startup))]
namespace Manateq
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            //ConfigureAuth(app);
        }
    }
}
