using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using 

[assembly: OwinStartup(typeof(OAuthServer.Startup))]

namespace OAuthServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var options = new 
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.Use.
        }
    }
}
