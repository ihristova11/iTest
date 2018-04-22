using iTest.Data.Models.Implementations;
using iTest.DTO;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using iTest.Web.Areas.Admin.Controllers.Abstract;
using iTest.Web.Areas.Admin.Controllers.Models;
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

        public async Task<IActionResult> CreateAsync()
            => View(new TestViewModel
            {
                CreatedOn = DateTime.UtcNow,
                Categories = await this.GetCategoriesAsync()
            });

        [HttpPost]
        public async Task<IActionResult> CreateAsync(TestViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.GetCategoriesAsync();
                return View(model);
            }

            var test = this.tests.ExistsByNameAsync(model.Name);

            if (!(await test))
            {
                await this.tests.CreateAsync(
                model.Name,
                model.RequestedTime,
                model.AuthorId = this.userManager.GetUserId(this.HttpContext.User),
                model.Category,
                model.Questions);
            }

            this.toastr.AddSuccessToastMessage($"Test {model.Name} created successfully!");

            return this.Redirect("/admin/");
        }


        public async Task<IActionResult> PublishAsync()
            => await Task.Run(() => View());

        [HttpPost]
        public async Task<IActionResult> PublishAsync(TestViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var dto = this.mapper.MapTo<TestDTO>(model);
            dto.AuthorId = this.userManager.GetUserId(this.HttpContext.User);

            await this.tests.PublishAsync(dto);

            this.toastr.AddSuccessToastMessage($"Test {model.Name} published successfully!");
            return this.Redirect("/admin/");
        }

        public async Task<IActionResult> EditAsync(int id)
        {
            var tests = await this.tests.FindByIdAsync(id);

            var test = tests.SingleOrDefault(x => x.Id == id);

            if (test == null)
            {
                return NotFound();
            }

            return View(new TestViewModel
            {
                Name = test.Name,
                RequestedTime = test.RequestedTime,
                Category = test.Category,
                Questions = test.Questions.ToList()
            });

        }

        public async Task<IActionResult> DeleteAsync(int id)
            => await Task.Run(() => View(id));

        public async Task<IActionResult> DeleteTestAsync(int id)
        {
            await this.tests.DeleteAsync(id);

            this.toastr.AddAlertToastMessage($"Test deleted successfully!");

            return this.Redirect("/admin/");
        }

        private async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
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
