using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab25MVC.Startup))]
namespace Lab25MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
