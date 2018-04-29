using iTest.DTO;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using iTest.Web.Areas.Admin.Controllers.Abstract;
using iTest.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Threading.Tasks;

namespace iTest.Web.Areas.Admin.Controllers
{
    public class AdminCategoryController : AdminController
    {
        private readonly IAdminCategoryService categories;
        private readonly IMappingProvider mapper;
        private readonly IToastNotification toastr;

        public AdminCategoryController(IAdminTestService tests, IAdminCategoryService categories, IMappingProvider mapper, IToastNotification toastr)
        {
            this.categories = categories ?? throw new ArgumentNullException(nameof(categories));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.toastr = toastr ?? throw new ArgumentNullException(nameof(toastr));
        }

        public async Task<IActionResult> Create()
                => await Task.Run(() => View());

        [HttpPost]
        public async Task<IActionResult> Create(AdminCategoryViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var category = this.categories.ExistsByNameAsync(model.Name);

            if (!(await category))
            {
                var dto = new CategoryDTO
                {
                    Name = model.Name,
                };

                await this.categories.CreateAsync(dto);
            }

            this.toastr.AddSuccessToastMessage($"Category {model.Name} created successfully!");

            return this.Redirect("/admin/");
        }


        public async Task<IActionResult> Publish()
            => await Task.Run(() => View());

        [HttpPost]
        public async Task<IActionResult> Publish(AdminCategoryViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var dto = this.mapper.MapTo<CategoryDTO>(model);
            await this.categories.PublishAsync(dto);

            this.toastr.AddSuccessToastMessage($"Category {model.Name} published successfully!");

            return this.Redirect("/admin/");
        }


        public async Task<IActionResult> Edit(string name)
        {
            var category = await this.categories.FindByNameAsync(name);

            if (category == null)
            {
                return NotFound();
            }

            return View(new AdminCategoryViewModel
            {
                Name = category.Name
            });

        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = this.mapper.MapTo<CategoryDTO>(model);

            var category = await this.categories.ExistsByNameAsync(model.Name);

            if (!category)
            {
                return NotFound();
            }

            await this.categories.UpdateAsync(dto);

            this.toastr.AddSuccessToastMessage($"Category {model.Name} updated successfully!");

            return this.Redirect("/admin/");
        }

        public async Task<IActionResult> Delete()
            => await Task.Run(() => View());


        public async Task<IActionResult> Delete(int id)
        {
            await this.categories.DeleteAsync(id);

            this.toastr.AddAlertToastMessage($"Category deleted successfully!");

            return this.Redirect("/admin/");
        }
    }
}