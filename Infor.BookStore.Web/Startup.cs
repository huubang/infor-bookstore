using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Infor.BookStore.Web.Startup))]
namespace Infor.BookStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
