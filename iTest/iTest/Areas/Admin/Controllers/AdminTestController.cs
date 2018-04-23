using iTest.Data.Models.Implementations;
using iTest.DTO;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using iTest.Web.Areas.Admin.Controllers.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTest.Web.Areas.Admin.Models;

namespace iTest.Web.Areas.Admin.Controllers
{
    public class AdminTestController : AdminController
    {
        private readonly IAdminTestService testsServices;
        private readonly IAdminCategoryService categories;
        private readonly IMappingProvider mapper;
        private readonly UserManager<User> userManager;
        private readonly IToastNotification toastr;

        public AdminTestController(IAdminTestService testsServices, IAdminCategoryService categories, IMappingProvider mapper, UserManager<User> userManager, IToastNotification toastr)
        {
            this.testsServices = testsServices ?? throw new ArgumentNullException(nameof(testsServices));
            this.categories = categories ?? throw new ArgumentNullException(nameof(categories));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.toastr = toastr ?? throw new ArgumentNullException(nameof(toastr));
        }

        public async Task<IActionResult> Create()
            => await Task.Run(() => View(new AdminTestViewModel
            {
                CreatedOn = DateTime.UtcNow,
                //Categories = await this.GetCategoriesAsync()
            }));

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AdminTestViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                //model.Categories = await this.GetCategoriesAsync();
                return View("Create", model);
            }

            var test = this.testsServices.ExistsByNameAsync(model.Name);

            if (!(await test))
            {
                var dto = new TestDTO
                {
                    Name = model.Name,
                    RequestedTime = model.RequestedTime,
                    AuthorId = model.AuthorId = this.userManager.GetUserId(this.HttpContext.User), // TODO required??
                    Category = model.Category,
                    Questions = model.Questions
                };

                await this.testsServices.CreateAsync(dto);
            }

            this.toastr.AddSuccessToastMessage($"Test {model.Name} created successfully!");

            return this.Redirect("/admin/");
        }

        public async Task<IActionResult> PublishAsync()
            => await Task.Run(() => View());

        [HttpPost]
        public async Task<IActionResult> PublishAsync(AdminTestViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var dto = this.mapper.MapTo<TestDTO>(model);
            dto.AuthorId = this.userManager.GetUserId(this.HttpContext.User);

            await this.testsServices.PublishAsync(dto);

            this.toastr.AddSuccessToastMessage($"Test {model.Name} published successfully!");
            return this.Redirect("/admin/");
        }

        public async Task<IActionResult> EditAsync(int id)
        {
            var test = await this.testsServices.FindByIdAsync(id);

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

        public async Task<IActionResult> DeleteAsync(int id)
            => await Task.Run(() => View(id));

        public async Task<IActionResult> DeleteTestAsync(int id)
        {
            await this.testsServices.DeleteAsync(id);

            this.toastr.AddAlertToastMessage($"Test deleted successfully!");

            return this.Redirect("/admin/");
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
