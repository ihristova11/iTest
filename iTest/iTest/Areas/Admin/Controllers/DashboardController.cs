using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

namespace iTest.Web.Areas.Admin.Controllers
{
    public class DashboardController : AdminController
    {
        private readonly IMappingProvider mapper;
        private readonly IAdminTestService tests;
        private readonly IUserTestService userTests;
        private readonly IResultService resultService;
        private readonly UserManager<User> userManager;

        public DashboardController(IMappingProvider mapper, IAdminTestService tests, UserManager<User> userManager)
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

        [HttpGet]
        [Authorize]
        public IActionResult Publish()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Disable()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}