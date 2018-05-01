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
        private readonly IAdminCategoryService categoryService;
        private readonly IMappingProvider mapper;
        private readonly IToastNotification toastr;

        public AdminCategoryController(IAdminTestService tests, IAdminCategoryService categoryService, IMappingProvider mapper, IToastNotification toastr)
        {
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
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

            var category = this.categoryService.ExistsByNameAsync(model.Name);

            if (!(await category))
            {
                var dto = new CategoryDTO
                {
                    Name = model.Name,
                    CreatedOn = DateTime.UtcNow
                };

                //var dto = this.mapper.InlineMapTo<AdminCategoryViewModel, CategoryDTO>(model, opt => opt.ConfigureMap().ForAllMembers(dest => dest.Ignore()));

                await this.categoryService.CreateAsync(dto);
            }

            this.toastr.AddSuccessToastMessage($"Category {model.Name} created successfully!");

            return this.Redirect("/");
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

            await this.categoryService.PublishAsync(dto);

            this.toastr.AddSuccessToastMessage($"Category {model.Name} published successfully!");

            return this.Redirect("/admin/");
        }


        public async Task<IActionResult> Edit(string name)
        {
            var category = await this.categoryService.FindByNameAsync(name);

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

            var category = await this.categoryService.ExistsByNameAsync(model.Name);

            if (!category)
            {
                return NotFound();
            }

            await this.categoryService.UpdateAsync(dto);

            this.toastr.AddSuccessToastMessage($"Category {model.Name} updated successfully!");

            return this.Redirect("/admin/");
        }

        public async Task<IActionResult> Delete()
            => await Task.Run(() => View());


        public async Task<IActionResult> Delete(int id)
        {
            await this.categoryService.DeleteAsync(id);

            this.toastr.AddAlertToastMessage($"Category deleted successfully!");

            return this.Redirect("/admin/");
        }
    }
}