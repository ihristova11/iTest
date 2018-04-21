using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using iTest.Web.Areas.Admin.Controllers.Abstract;
using iTest.Web.Areas.Admin.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public AdminTestsController(IAdminTestService tests, IAdminCategoryService categories, IMappingProvider mapper)
        {
            this.tests = tests ?? throw new ArgumentNullException(nameof(tests));
            this.categories = categories ?? throw new ArgumentNullException(nameof(categories));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IActionResult> CreateAsync()
            => View(new CreateEditTestViewModel
            {
                CreatedOn = DateTime.UtcNow,
                Categories = await this.GetCategoriesAsync()
            });


        [HttpPost]
        public async Task<IActionResult> Create(CreateEditTestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await this.GetCategoriesAsync();
                return View(model);
            }

            var test = this.tests.ExistsByNameAsync(model.Name);

            if (!(await test))
            {
                //await this.tests.CreateAsync(
                //model.Name = name;
                //model.RequestedTime = requestedTime;
                //model.Category = this.mapper.MapTo<Category>(category);
            }

            //Toastr.AddSuccessMessage($"Test {model.Name} created successfully!");

            return Redirect("/admin/");
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
