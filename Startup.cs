using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Delete.Startup))]
namespace Delete
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
