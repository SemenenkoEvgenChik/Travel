using System.Web;
using System.Web.Mvc;
using TravelAgency.WEB.Filters;

namespace TravelAgency.WEB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ModelStateFilter());
        }
    }
}
