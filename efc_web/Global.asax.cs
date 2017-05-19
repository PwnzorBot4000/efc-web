using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace efc_web
{
	public partial class Global : HttpApplication
	{
		protected void Application_Start()
		{
            EngineManager.initialize();
			GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
		}
	}
}
