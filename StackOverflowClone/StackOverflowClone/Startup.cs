using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StackOverflowClone.Startup))]
namespace StackOverflowClone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
