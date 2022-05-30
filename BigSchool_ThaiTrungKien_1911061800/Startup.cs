using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BigSchool_ThaiTrungKien_1911061800.Startup))]
namespace BigSchool_ThaiTrungKien_1911061800
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
