using System.Web;
using System.Web.Mvc;
using TrailerOnline.Filters;

namespace TrailerOnline
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            
        }
    }
}