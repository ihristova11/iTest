using iTest.Data.Models;
using iTest.Data.Models.Enums;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.User.Contracts;
using iTest.Web.Areas.Users.Controllers.Abstract;
using iTest.Web.Areas.Users.Models.Dashboard;
using iTest.Web.Areas.Users.Models.Details;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace iTest.Web.Areas.Users.Controllers
{
    public class DashboardController : UserController
    {
        private readonly IUserTestService tests;
        private readonly IUserCategoryService categories;
        private readonly IMappingProvider mapper;
        private readonly UserManager<User> userManager;
        private readonly IToastNotification toastr;

        public DashboardController(IUserTestService tests, IUserCategoryService categories, IMappingProvider mapper, UserManager<User> userManager, IToastNotification toastr)
        {
            this.tests = tests;
            this.categories = categories;
            this.mapper = mapper;
            this.userManager = userManager;
            this.toastr = toastr;
        }

        public IActionResult Index()
        {
            var user = this.userManager.GetUserName(this.HttpContext.User);

            var model = new UserDashboardViewModel
            {
                Author = user
            };

            var categories = this.categories.All();
            model.Categories = this.mapper.ProjectTo<UserCategoryViewModel>(categories);

            var tests = this.tests.All();
            model.Tests = this.mapper.ProjectTo<UserTestViewModel>(tests);

            foreach (var category in model.Categories)
            {
                var testsToAdd = this.tests.AllByCategory(category.Name);
                if (testsToAdd.Any())
                {
                    category.Tests.AddRange(testsToAdd);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {

            var test = this.tests.FindById(id);
            var user = await this.userManager.GetUserAsync(HttpContext.User);

            var startedTest = this.tests.MapStartedTestData(user.Id, test.Id);

            if (startedTest.ResultStatus != ResultStatus.Default)
            {
                return this.RedirectToAction("Index", "Dashboard");
            }

            startedTest.StartedOn = DateTime.Now;

            var model = new UserTestDetailsViewModel();
            model = this.mapper.MapTo<UserTestDetailsViewModel>(startedTest);

            this.mapper.ProjectTo<UserQuestionViewModel>(model.Questions).ToList();

            return await Task.Run(() => View(model));
        }

        [HttpPost]
        public IActionResult Details(UserTestDetailsViewModel model)
        {
            model.SubmittedOn = DateTime.Now;
            model.ExecutedTime = model.SubmittedOn.Subtract(model.StartedOn);

            var allowedTimeInSeconds = model.ExecutedTime.TotalSeconds;

            //var startedTest = this.tests.MapStartedTestData(model.UserId, model.TestId);

            var countCorrectQuestions = 0;

            foreach (var question in model.Questions)
            {
                if (question.IsCorrect)
                {
                    countCorrectQuestions++;
                }
            }

            double result = (countCorrectQuestions / model.Questions.Count()) * 100;

            if (result >= 80.0)
            {
                model.ResultStatus = ResultStatus.Passed;
            }
            else
            {
                model.ResultStatus = ResultStatus.Failed;
            }

            this.mapper.MapTo<UserTestDetailsViewModel>(model);

            return RedirectToAction("Index", "Dashboard", new { area = "users" });
        }
    }
}