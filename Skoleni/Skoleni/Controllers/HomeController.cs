using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Skoleni.ViewModels;

namespace Skoleni.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["mainVolba"] = 1;
            return View();
        }

        public IActionResult About()
        {
            ViewData["mainVolba"] = 1;
            return View();
        }


        public IActionResult Privacy()
        {
            ViewData["mainVolba"] = 1;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ViewData["mainVolba"] = 1;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
