using iTest.DTO;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using iTest.Web.Areas.Admin.Controllers.Abstract;
using iTest.Web.Areas.Admin.Models.Categories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace iTest.Web.Areas.Admin.Controllers
{
    public class AdminCategoriesController : AdminController
    {
        private readonly IAdminTestService tests;
        private readonly IAdminCategoryService categories;
        private readonly IMappingProvider mapper;

        public AdminCategoriesController(IAdminTestService tests, IAdminCategoryService categories, IMappingProvider mapper)
        {
            this.tests = tests ?? throw new ArgumentNullException(nameof(tests));
            this.categories = categories ?? throw new ArgumentNullException(nameof(categories));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
        public async Task<IActionResult> Create(AdminCategoryViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            var category = this.categories.ExistsByNameAsync(model.Name);

            if (await category)
            {
                TempData["Success-Message"] = $"Category {model.Name} aleready exits!";

                return View();
            }
            else
            {
                var dto = this.mapper.MapTo<CategoryDTO>(model);

                await this.categories.CreateAsync(dto);

                TempData["Success-Message"] = $"Category {model.Name} created successfully!";

                return RedirectToAction("Index", "Dashboard", new { area = "admin" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            return await Task.Run(() => View());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminCategoryViewModel model)
        {
            var dto = this.mapper.MapTo<CategoryDTO>(model);

            await this.categories.UpdateAsync(dto);

            TempData["Success-Message"] = $"Category {model.Name} updated successfully!";

            return RedirectToAction("Index", "Dashboard", new { area = "admin" });
        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await this.categories.DeleteAsync(id);

        //    this.toastr.AddAlertToastMessage($"Category deleted successfully!");

        //    return this.RedirectToAction("Index", "AdminCategory");
        //}
    }
}