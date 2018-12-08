/* ITSE 1430
 * Dalia Hussin
 * 12/8/2018
 */
using System.Web;
using System.Web.Mvc;

namespace EventPlanner.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
