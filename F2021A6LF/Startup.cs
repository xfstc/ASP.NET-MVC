using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(F2021A6LF.Startup))]

namespace F2021A6LF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
