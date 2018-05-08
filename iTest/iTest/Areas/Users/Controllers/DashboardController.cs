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

        public DashboardController(IUserTestService tests, IUserCategoryService categories, IMappingProvider mapper, UserManager<User> userManager)
        {
            this.tests = tests;
            this.categories = categories;
            this.mapper = mapper;
            this.userManager = userManager;
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

            var resultStatus = this.tests.GetTestResultByUser(userId, test.Id);

            if (resultStatus != ResultStatus.Default)
            {
                TempData["Success-Message"] = "You have already submitted this test.";
                return RedirectToAction("Index", "Dashboard", new { area = "Users" });

            }

            var model = new UserTestDetailsViewModel();

            model = this.mapper.MapTo<UserTestDetailsViewModel>(test);

            TimeSpan requestedTime = TimeSpan.FromMinutes(test.RequestedTime);

            model.Name = test.Name;
            model.CategoryName = test.Category.Name;
            model.StartedOn = DateTime.Now;
            model.RequestedTime = requestedTime;
            model.QuestionsCount = test.Questions.ToList().Count();
            model.UserId = userId;
            model.TestId = test.Id;

            TempData["Success-Message"] = "You have started the test. Good luck...";

            return View(model);
        }

        [HttpPost]
        public IActionResult Details([FromForm] UserTestDetailsViewModel model)
        {
            model.SubmittedOn = DateTime.Now;
            model.ExecutionTime = DateTime.Now.Subtract(model.StartedOn);

            var dto = this.mapper.MapTo<UserTestDTO>(model);

            if (dto.ResultStatus != ResultStatus.Default)
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Users" });
            }

            var correctAsnwers = dto.CorrectAnswers;
            var questionsCount = dto.QuestionsCount;


            if (correctAsnwers == 0)
            {
                dto.ResultStatus = ResultStatus.Failed;
            }

            else
            {
                var result = (correctAsnwers / questionsCount) * 100;

                if (result >= 80.0)
                {
                    dto.ResultStatus = ResultStatus.Passed;
                }
                else
                {
                    dto.ResultStatus = ResultStatus.Failed;
                }
            }

            this.tests.SaveResult(dto);

            TempData["Success-Message"] = "Please wait, your test is being submitted"; // ViewData[]

            return RedirectToAction("Index", "Dashboard", new { area = "Users" });
            //return Json(Url.Action("Index", "Dashboard", new { area = "Users" }));
        }
    }
}