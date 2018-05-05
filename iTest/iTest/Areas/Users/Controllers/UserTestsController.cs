using iTest.Data.Models;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.User.Contracts;
using iTest.Web.Areas.Users.Controllers.Abstract;
using iTest.Web.Areas.Users.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Threading.Tasks;

namespace iTest.Web.Areas.Users.Controllers
{
    public class UserTestsController : UserController
    {
        private readonly IUserTestService tests;
        private readonly IUserCategoryService categories;
        private readonly IMappingProvider mapper;
        private readonly UserManager<User> userManager;
        private readonly IToastNotification toastr;

        public UserTestsController(IUserTestService tests, IUserCategoryService categories, IMappingProvider mapper, UserManager<User> userManager, IToastNotification toastr)
        {
            this.tests = tests;
            this.categories = categories;
            this.mapper = mapper;
            this.userManager = userManager;
            this.toastr = toastr;
        }

        public async Task<IActionResult> Index()
        {
            var user = this.userManager.GetUserName(this.HttpContext.User);

            var model = new UserDashboardViewModel
            {
                Author = user
            };

            var categories = this.categories.All();
            model.Categories = this.mapper.ProjectTo<UserCategoryViewModel>(categories);

            var tests = this.tests.GetRandomTest(1);
            model.Tests = this.mapper.ProjectTo<UserTestViewModel>(tests);

            return await Task.Run(() => View(model));
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = new DetailsViewModel();

            var test = this.tests.FindByNameAsync(id);
            model.Test = this.mapper.MapTo<UserTestDetailsViewModel>(test);

            // model.Questions = this.mapper.ProjectTo<QuestionViewModel>(test.Questions).ToList();

            return await Task.Run(() => View());
        }
    }
}