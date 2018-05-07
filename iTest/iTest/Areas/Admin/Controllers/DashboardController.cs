using iTest.Data.Models;
using iTest.Data.Models.Enums;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using iTest.Services.Data.User.Contracts;
using iTest.Web.Areas.Admin.Controllers.Abstract;
using iTest.Web.Areas.Admin.Models.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTest.Web.Areas.Admin.Controllers
{
    public class DashboardController : AdminController
    {
        private readonly IMappingProvider mapper;
        private readonly IAdminTestService tests;
        private readonly IUserTestService userTests;
        private readonly IResultService resultService;
        private readonly UserManager<User> userManager;

        public DashboardController(IMappingProvider mapper, IAdminTestService tests, UserManager<User> userManager, IMemoryCache cache)
        {
            this.mapper = mapper ?? throw new ArgumentNullException("Mapper can not be null");
            this.tests = tests ?? throw new ArgumentNullException("Tests service cannot be null");
            this.userManager = userManager ?? throw new ArgumentNullException("User manager cannot be null");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            // Get current user
            var admin = await this.userManager.GetUserAsync(HttpContext.User);

            var allTestsDto = this.tests.AllByAuthor(admin.Id);

            var allTestsViewModel = new List<TestViewModel>();

            //TestViewModels creating
            foreach (var testDto in allTestsDto)
            {
                var curr = new TestViewModel()
                {
                    Id = testDto.Id,
                    TestName = testDto.Name,
                    CategoryName = testDto.CategoryName,
                    Status = Enum.GetName(typeof(Status), testDto.Status)
                };

                allTestsViewModel.Add(curr);
            }

            // IndexViewModel creating
            var model = new IndexViewModel()
            {
                AdminName = admin.UserName,
                Tests = allTestsViewModel
            };

            return View("Index", model);

        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Publish(int id)
        {
            try
            {
                this.tests.PublishExistingTest(id);
                TempData["Success-Message"] = "You successfully published a test!";
            }
            catch (Exception ex)
            {
                TempData["Error-Message"] = string.Format("Publishing test failed! {0}", ex.Message);
            }

            return Json(Url.Action("Index", "Dashboard", new { area = "Admin" }));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Disable(int id)
        {
            try
            {
                this.tests.Disable(id);
                TempData["Success-Message"] = "You successfully set test status as Draft!";
            }
            catch (Exception ex)
            {
                TempData["Error-Message"] = string.Format("Disable test failed! {0}", ex.Message);
            }

            return Json(Url.Action("Index", "Dashboard", new { area = "Admin" }));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.tests.DeleteAsync(id);
                TempData["Success-Message"] = "You successfully deleted a test!";
            }
            catch (Exception ex)
            {
                TempData["Error-Message"] = string.Format("Deliting test failed! {0}", ex.Message);
            }

            return Json(Url.Action("Index", "Dashboard", new { area = "Admin" }));
        }
    }
}