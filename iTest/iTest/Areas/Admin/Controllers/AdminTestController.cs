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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTest.Web.Areas.Admin.Controllers
{
    public class AdminTestController : AdminController
    {
        private readonly IAdminTestService testServices;
        private readonly IAdminCategoryService categoryService;
        private readonly IMappingProvider mapper;
        private readonly UserManager<User> userManager;
        private readonly IToastNotification toastr;

        public AdminTestController(IAdminTestService testServices, IAdminCategoryService categoryService, IMappingProvider mapper, UserManager<User> userManager, IToastNotification toastr)
        {
            this.testServices = testServices;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.userManager = userManager;
            this.toastr = toastr;
        }

        public async Task<IActionResult> Create()
            => View(new AdminTestViewModel
            {
                CreatedOn = DateTime.UtcNow,
                Categories = await this.GetCategoriesAsync()
            });

        [HttpPost]
        public async Task<IActionResult> Create(AdminTestViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.GetCategoriesAsync();
                return View("Create", model);
            }

            var test = this.testServices.ExistsByNameAsync(model.Name);

            if (!(await test))
            {
                var dto = new TestDTO
                {
                    Name = model.Name,
                    RequestedTime = model.RequestedTime,
                    AuthorId = model.Author = this.userManager.GetUserId(this.HttpContext.User),
                    Category = model.Category,
                    Questions = model.Questions
                };

                this.testServices.Create(dto);
            }

            this.toastr.AddSuccessToastMessage($"Test {model.Name} created successfully!");

            return this.Redirect("/admin/");
        }

        public async Task<IActionResult> Home()
            => await Task.Run(() => View("Index"));

        public async Task<IActionResult> Publish()
            => await Task.Run(() => View());

        [HttpPost]
        public IActionResult Publish(AdminTestViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var dto = this.mapper.MapTo<TestDTO>(model);
            dto.AuthorId = this.userManager.GetUserId(this.HttpContext.User);

            this.testServices.Publish(dto);

            this.toastr.AddSuccessToastMessage($"Test {model.Name} published successfully!");
            return this.Redirect("/admin/");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var test = await this.testServices.FindByIdAsync(id);

            if (test == null)
            {
                return NotFound();
            }

            return View(new AdminTestViewModel
            {
                Name = test.Name,
                RequestedTime = test.RequestedTime,
                Category = test.Category,
                Questions = test.Questions.ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminTestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = this.mapper.MapTo<TestDTO>(model);

            var test = await this.testServices.ExistsByNameAsync(model.Name);

            if (!test)
            {
                return NotFound();
            }

            await this.testServices.UpdateAsync(dto);

            this.toastr.AddSuccessToastMessage($"Test {model.Name} updated successfully!");

            return this.Redirect("/admin/");
        }

        public async Task<IActionResult> Delete()
        => await Task.Run(() => View());

        public async Task<IActionResult> Delete(int id)
        {
            await this.testServices.DeleteAsync(id);

            this.toastr.AddAlertToastMessage($"Test deleted successfully!");

            return this.Redirect("/admin/");
        }

        protected async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var categories = await this.categoryService.AllAsync();

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
