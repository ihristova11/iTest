using iTest.Data.Models;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using iTest.Services.Data.User.Contracts;
using iTest.Web.Areas.Users.Controllers.Abstract;
using iTest.Web.Areas.Users.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Threading.Tasks;

namespace iTest.Web.Areas.Users.Controllers
{
    public class TestsController : UserController
    {
        private readonly IAdminTestService tests;
        private readonly IUserCategoryService categories;
        private readonly IMappingProvider mapper;
        private readonly UserManager<User> userManager;
        private readonly IToastNotification toastr;

        public TestsController(IAdminTestService tests, IUserCategoryService categories, IMappingProvider mapper, UserManager<User> userManager, IToastNotification toastr)
        {
            this.tests = tests;
            this.categories = categories;
            this.mapper = mapper;
            this.userManager = userManager;
            this.toastr = toastr;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel();

            var allCategories = this.categories.All();
            model.Categories = this.mapper.ProjectTo<CategoryViewModel>(allCategories);

            return await Task.Run(() => View(model));
        }
    }
}