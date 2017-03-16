using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuctionInventory.Startup))]
namespace AuctionInventory
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
