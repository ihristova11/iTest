using iTest.Data.Models;
using iTest.DTO;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using iTest.Web.Areas.Admin.Controllers.Abstract;
using iTest.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTest.Web.Areas.Admin.Controllers
{
    public class AdminTestController : AdminController
    {
        private readonly IAdminTestService tests;
        private readonly IAdminCategoryService categories;
        private readonly IMappingProvider mapper;
        private readonly UserManager<User> userManager;
        private readonly IToastNotification toastr;

        public AdminTestController(IAdminTestService tests, IAdminCategoryService categories, IMappingProvider mapper, UserManager<User> userManager, IToastNotification toastr)
        {
            this.tests = tests;
            this.categories = categories;
            this.mapper = mapper;
            this.userManager = userManager;
            this.toastr = toastr;
        }

        public async Task<IActionResult> Dashboard()
            => await Task.Run(() => View("Index"));

        public async Task<IActionResult> Create()
            => View(new AdminTestViewModel
            {
                Categories = await this.GetCategoriesAsync()
            });

        [HttpPost]
        public async Task<IActionResult> Create(AdminTestViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var test = this.tests.ExistsByNameAsync(model.Name);

            if (!(await test))
            {
                var dto = this.mapper.MapTo<TestDTO>(model);
                dto.AuthorId = this.userManager.GetUserId(this.HttpContext.User);
                this.tests.Create(dto);
            }

            this.toastr.AddSuccessToastMessage($"Test {model.Name} created successfully!");

            return this.RedirectToAction("Index", "Admin");
        }

        public async Task<IActionResult> Edit()
            => await Task.Run(() => View("Index"));

        [HttpPost]
        public async Task<IActionResult> Edit(AdminTestViewModel model)
        {
            var dto = this.mapper.MapTo<TestDTO>(model);
            dto.AuthorId = this.userManager.GetUserId(this.HttpContext.User);

            await this.tests.UpdateAsync(dto);

            this.toastr.AddSuccessToastMessage($"Test {model.Name} updated successfully!");

            return this.RedirectToAction("Details", "Test", new { id = model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.tests.DeleteAsync(id);

            this.toastr.AddAlertToastMessage($"Test deleted successfully!");

            return this.RedirectToAction("Index", "Admin");
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
