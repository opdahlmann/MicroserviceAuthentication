using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(MicroserviceAuthentication.Autenticate.Startup))]

namespace MicroserviceAuthentication.Autenticate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
