using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseRegister.Startup))]
namespace CourseRegister
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
