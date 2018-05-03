using iTest.DTO;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using iTest.Web.Areas.Admin.Controllers.Abstract;
using iTest.Web.Areas.Admin.Models.Categories;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Threading.Tasks;

namespace iTest.Web.Areas.Admin.Controllers
{
    public class CategoriesController : AdminController
    {
        private readonly IAdminTestService tests;
        private readonly IAdminCategoryService categories;
        private readonly IMappingProvider mapper;
        private readonly IToastNotification toastr;

        public CategoriesController(IAdminTestService tests, IAdminCategoryService categories, IMappingProvider mapper, IToastNotification toastr)
        {
            this.tests = tests ?? throw new ArgumentNullException(nameof(tests));
            this.categories = categories ?? throw new ArgumentNullException(nameof(categories));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.toastr = toastr ?? throw new ArgumentNullException(nameof(toastr));
        }

        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> Create()
        {
            return await Task.Run(() => View());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEditCategoryViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            var category = this.categories.ExistsByNameAsync(model.Name);

            if (await category)
            {
                this.toastr.AddSuccessToastMessage($"Category {model.Name} aleready exits!");
                return View();
            }

            var dto = this.mapper.MapTo<CategoryDTO>(model);
            await this.categories.CreateAsync(dto);
            this.toastr.AddSuccessToastMessage($"Category {model.Name} created successfully!");
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            return await Task.Run(() => View());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateEditCategoryViewModel model)
        {
            var dto = this.mapper.MapTo<CategoryDTO>(model);

            await this.categories.UpdateAsync(dto);

            this.toastr.AddSuccessToastMessage($"Category {model.Name} updated successfully!");

            return this.RedirectToAction("Edit", "Category", new { id = model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.categories.DeleteAsync(id);

            this.toastr.AddAlertToastMessage($"Category deleted successfully!");

            return this.RedirectToAction("Home", "AdminCategory");
        }
    }
}