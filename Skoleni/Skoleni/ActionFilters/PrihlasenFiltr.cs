using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Skoleni.Models;
using System.Linq;

namespace Skoleni.ActionFilters
{
    public class PrihlasenFiltr : ActionFilterAttribute, IActionFilter
    {
   
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int? idUzivatele = filterContext.HttpContext.Session.GetInt32("userId");

            if (idUzivatele == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", "Home"},
                        {"action", "Login"}
                    });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
