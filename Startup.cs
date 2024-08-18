using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlWarraq.Startup))]
namespace AlWarraq
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
