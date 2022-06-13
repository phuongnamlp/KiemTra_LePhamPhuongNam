using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KiemTra_LePhamPhuongNam.Startup))]
namespace KiemTra_LePhamPhuongNam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
