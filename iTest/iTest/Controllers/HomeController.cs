using System.Diagnostics;
using iTest.Data;
using iTest.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace iTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly iTestDbContext ctx;

        public HomeController(iTestDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
