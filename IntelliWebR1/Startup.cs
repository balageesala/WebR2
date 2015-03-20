using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(IntelliWebR1.Startup))]
namespace IntelliWebR1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
             app.MapSignalR(); 
        }
    }

}
