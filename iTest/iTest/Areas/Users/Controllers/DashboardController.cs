using iTest.Data.Models;
using iTest.Data.Models.Enums;
using iTest.DTO;
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

        public IActionResult Details(int id)
        {
            var userId = this.userManager.GetUserId(this.HttpContext.User);
            var test = this.tests.FindById(id);

            var model = new UserTestDetailsViewModel();
            model = this.mapper.MapTo<UserTestDetailsViewModel>(test);

            TimeSpan requestedTime = TimeSpan.FromMinutes(test.RequestedTime);

            model.Name = test.Name;
            model.CategoryName = test.Category.Name;
            model.StartedOn = DateTime.Now;
            model.RequestedTime = requestedTime;
            model.QuestionsCount = test.Questions.ToList().Count();
            model.UserId = userId;

            return View(model);
        }

        [HttpPost]
        public IActionResult Details(UserTestDetailsViewModel model)
        {
            var dto = this.mapper.MapTo<TestDTO>(model);
            var dto2 = this.mapper.MapTo<UserTestDTO>(model);

            if (model.ResultStatus != ResultStatus.Default)
            {
                return Json(Url.Action("Index", "Dashboard", new { area = "Users" }));
            }

            model.SubmittedOn = DateTime.Now;
            model.ExecutionTime = model.SubmittedOn.Subtract(model.StartedOn);

            if (model.CorrectAnswers == 0)
            {
                model.ResultStatus = ResultStatus.Failed;
            }

            else
            {
                double result = (model.CorrectAnswers / model.QuestionsCount) * 100;

                if (result >= 80.0)
                {
                    model.ResultStatus = ResultStatus.Passed;
                }
                else
                {
                    model.ResultStatus = ResultStatus.Failed;
                }
            }


            this.tests.SaveResult(dto);

            return Json(Url.Action("Index", "Dashboard", new { area = "Users" }));
        }
    }
}