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
using iTest.Data.Models;

namespace iTest.Web.Areas.Admin.Controllers
{
    public class ManageTestController : AdminController
    {
        private readonly IAdminTestService testService;
        private readonly IAdminCategoryService categoryService;
        private readonly IMappingProvider mapper;
        private readonly UserManager<User> userManager;
        private readonly IToastNotification toastr;

        public ManageTestController(IAdminTestService testServices, IAdminCategoryService categoryService, IMappingProvider mapper, UserManager<User> userManager, IToastNotification toastr)
        {
            this.testService = testServices ?? throw new ArgumentNullException(nameof(testServices));
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.toastr = toastr ?? throw new ArgumentNullException(nameof(toastr));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("CreateTest", new CreateTestViewModel
            {
                Categories = await this.GetCategoriesAsync()
            });
        }

        //public IActionResult CreateQuestion()
        //{
        //    return PartialView("_CreateQuestion");
        //}

        //public IActionResult CreateAnswer()
        //{
        //    return PartialView("_CreateAnswer");
        //}

        [HttpGet]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        public IActionResult AddQuestion(CreateQuestionViewModel model)
        {
            return PartialView("_CreateQuestion", model);
        }

        [HttpGet]
        public IActionResult AddAnswer(CreateAnswerViewModel model)
        {
            return PartialView("_CreateAnswer", model);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(CreateTestViewModel model)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        model.Categories = await this.GetCategoriesAsync();
        //        return View("CreateTest", model);
        //    }

        //    var test = this.testServices.ExistsByNameAsync(model.Name);

        //    if (!(await test))
        //    {
        //        //var dto = new TestDTO
        //        //{
        //        //    Name = model.Name,
        //        //    RequestedTime = model.RequestedTime,
        //        //    AuthorId = model.AuthorId = this.userManager.GetUserId(this.HttpContext.User), // TODO required??
        //        //    Category = model.Category,
        //        //    Questions = this.mapper.MapTo<ICollection<QuestionDTO>>(model.Questions)
        //        //};

        //        var dto = this.mapper.MapTo<TestDTO>(model);

        //        await this.testServices.CreateAsync(dto);
        //    }

        //    this.toastr.AddSuccessToastMessage($"Test {model.Name} created successfully!");

        //    return this.Redirect("/admin/");
        //}

        [HttpPost]
        public IActionResult SaveTest([FromBody] CreateTestViewModel testViewModel)
        {
            testViewModel.AuthorId = this.userManager.GetUserId(this.HttpContext.User);
            if (this.ModelState.IsValid)
            {

                //var modelState = this.ModelState.IsValid;
                var testDTO = this.mapper.MapTo<TestDTO>(testViewModel);

                this.testService.Create(testDTO);
            }

            //return this.RedirectToAction("Home", "ManageTest");
            return Json(Url.Action("Home", "ManageTest", new { area = "Admin" }));
        }

        // added to test view
        [HttpGet]
        [ActionName("Home")]
        public async Task<IActionResult> Home()
            => await Task.Run(() => View("Index"));

        public async Task<IActionResult> PublishAsync()
            => await Task.Run(() => View());

        //[HttpPost]
        //public async Task<IActionResult> PublishAsync(CreateTestViewModel model)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var dto = this.mapper.MapTo<TestDTO>(model);
        //    dto.AuthorId = this.userManager.GetUserId(this.HttpContext.User);

        //    await this.testService.Publish(dto);

        //    this.toastr.AddSuccessToastMessage($"Test {model.Name} published successfully!");
        //    return this.Redirect("/admin/");
        //}

        //public async Task<IActionResult> EditAsync(int id)
        //{
        //    var test = await this.testServices.FindByIdAsync(id);

        //    if (test == null)
        //    {
        //        return NotFound();
        //    }

        //    return View("Create", new AdminTestViewModel
        //    {
        //        Name = test.Name,
        //        RequestedTime = test.RequestedTime,
        //        Category = test.Category,
        //        Questions = test.Questions.ToList()
        //    });
        //}

        public async Task<IActionResult> DeleteAsync(int id)
            => await Task.Run(() => View(id));

        public async Task<IActionResult> DeleteTestAsync(int id)
        {
            await this.testService.DeleteAsync(id);

            this.toastr.AddAlertToastMessage($"Test deleted successfully!");

            return this.Redirect("/admin/");
        }

        protected async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            //var categories = await this.categories.AllAsync();
            var categories = await this.categoryService
                                  .AllAsync();

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
