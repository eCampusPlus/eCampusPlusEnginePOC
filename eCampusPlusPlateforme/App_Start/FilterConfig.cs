using System.Web;
using System.Web.Mvc;

namespace eCampusPlusPlateforme
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
