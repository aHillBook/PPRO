using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Skoleni.Models;
using System.Linq;

namespace Skoleni.ActionFilters
{
    public class JazykyFiltr : ActionFilterAttribute, IActionFilter
    {
        private readonly DB _context;

        public JazykyFiltr(DB context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool povoleno = false;
            int? idUzivatele = filterContext.HttpContext.Session.GetInt32("userId");

            if (idUzivatele != null)
            {
                POpravneni po = _context.seznamOpravneni.Where(b => b.idUzivatele == idUzivatele).FirstOrDefault();
                if (po != null)
                {
                    if (po.idRole == 1)
                    {
                        povoleno = true;
                    }
                }
            }

            if (!povoleno)
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
