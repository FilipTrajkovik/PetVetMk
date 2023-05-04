using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetVetMk.Startup))]
namespace PetVetMk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
