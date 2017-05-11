using System.Web.Routing;

namespace efc_web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                routeName: "Default",
                routeUrl: "",
                physicalFile: "~/LoginPage.aspx"
            );
        }
    }
}
