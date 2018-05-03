using iTest.Data.Models;
using iTest.DTO;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using iTest.Web.Areas.Admin.Controllers.Abstract;
using iTest.Web.Areas.Admin.Models.Tests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTest.Web.Areas.Admin.Controllers
{
    public class AdminTestsController : AdminController
    {
        private readonly IAdminTestService tests;
        private readonly IAdminCategoryService categories;
        private readonly IMappingProvider mapper;
        private readonly UserManager<User> userManager;
        private readonly IToastNotification toastr;

        public AdminTestsController(IAdminTestService tests, IAdminCategoryService categories, IMappingProvider mapper, UserManager<User> userManager, IToastNotification toastr)
        {
            this.tests = tests ?? throw new ArgumentNullException(nameof(tests));
            this.categories = categories ?? throw new ArgumentNullException(nameof(categories));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.toastr = toastr ?? throw new ArgumentNullException(nameof(toastr));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("Create", new CreateTestViewModel
            {
                Categories = await this.GetCategoriesAsync()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTestViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            var test = this.tests.ExistsByNameAsync(model.Name);

            if (!(await test))
            {
                model.Author = this.userManager.GetUserId(this.HttpContext.User);
                var testDTO = this.mapper.MapTo<TestDTO>(model);
                await this.tests.CreateAsync(testDTO);
            }

            this.toastr.AddSuccessToastMessage($"Test {model.Name} created successfully!");
            return RedirectToAction("Index", "Tests", new { area = "admin" });
        }

        // added to test view

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View("Index"));
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            return await Task.Run(() => View("Create"));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminTestViewModel model)
        {
            var dto = this.mapper.MapTo<TestDTO>(model);
            dto.AuthorId = this.userManager.GetUserId(this.HttpContext.User);

            await this.tests.UpdateAsync(dto);

            this.toastr.AddSuccessToastMessage($"Test ${model.Name} updated successfully!");

            return RedirectToAction("Index", "Tests", new { area = "admin" });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.tests.DeleteAsync(id);

            this.toastr.AddAlertToastMessage($"Test deleted successfully!");

            return RedirectToAction("Index", "Tests", new { area = "admin" });
        }

        public IActionResult CreateQuestion()
        {
            return PartialView("_CreateQuestion");
        }

        public IActionResult CreateAnswer()
        {
            return PartialView("_CreateAnswer");
        }

        protected async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var categories = await this.categories.AllAsync();

            var categoriesList = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            })
            .ToList();

            return categoriesList;
        }
    }
}
