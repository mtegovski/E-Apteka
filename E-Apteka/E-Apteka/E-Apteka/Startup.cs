using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_Apteka.Startup))]
namespace E_Apteka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
