using System.Web;
using System.Web.Mvc;

namespace CRUD_Cascading_Dropdown_JQuery_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
