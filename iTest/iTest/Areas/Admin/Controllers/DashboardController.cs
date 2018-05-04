using System.Threading.Tasks;
using iTest.Web.Areas.Admin.Controllers.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace iTest.Web.Areas.Admin.Controllers
{
    public class DashboardController : AdminController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
            => await Task.Run(() => View("Index"));

    }
}