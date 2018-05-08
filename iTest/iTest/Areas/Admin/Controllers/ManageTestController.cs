using iTest.Data.Models;
using iTest.DTO;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using iTest.Web.Areas.Admin.Controllers.Abstract;
using iTest.Web.Areas.Admin.Models.ManageTest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTest.Web.Areas.Admin.Controllers
{
    public class ManageTestController : AdminController
    {
        private readonly string CacheKey = "cacheKey";
        private readonly IAdminTestService testService;
        private readonly IAdminCategoryService categoryService;
        private readonly IMappingProvider mapper;
        private readonly UserManager<User> userManager;
        private readonly IMemoryCache cache;

        public ManageTestController(IAdminTestService testServices, IAdminCategoryService categoryService, IMappingProvider mapper, UserManager<User> userManager, IMemoryCache cache)
        {
            this.testService = testServices ?? throw new ArgumentNullException(nameof(testServices));
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            // Look for cache key.
            if (!cache.TryGetValue(CacheKey, out IEnumerable<SelectListItem> allCategories))
            {
                // Key not in cache, so get data.
                allCategories = await this.GetCategoriesAsync();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()

                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60));

                // Save data in cache.
                cache.Set(CacheKey, allCategories, cacheEntryOptions);
            }

            return View(new CreateTestViewModel
            {
                Categories = allCategories
            });
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddQuestion(CreateQuestionViewModel model)
        {
            return PartialView("_CreateQuestion", model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddAnswer(CreateAnswerViewModel model)
        {
            return PartialView("_CreateAnswer", model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] CreateTestViewModel testViewModel)
        {
            bool isValidTest = true;

            if (testViewModel.Status == "Published")
            {
                if (!testViewModel.Questions.Any()) // no question -> not valid test
                {
                    isValidTest = false;
                }

                foreach (var question in testViewModel.Questions)
                {
                    if (question.Answers.Count < 2)
                    {
                        isValidTest = false;
                        break;
                    }
                }
            }

            testViewModel.AuthorId = this.userManager.GetUserId(this.HttpContext.User);

            if (this.ModelState.IsValid && isValidTest)
            {
                var testDTO = this.mapper.MapTo<TestDTO>(testViewModel);

                if (testViewModel.Status == "Published")
                {
                    TempData["Success-Message"] = "You successfully published a new test!";
                }
                else if (testViewModel.Status == "Draft")
                {
                    TempData["Success-Message"] = "You successfully created a new test!";
                }

                this.testService.Create(testDTO);

                return Json(Url.Action("Index", "Dashboard", new { area = "Admin" }));
            }

            TempData["Error-Message"] = "Test publish failed!";
            return Json(Url.Action("Index", "Dashboard", new { area = "Admin" }));
        }

        [Authorize]
        protected async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
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

        [HttpGet]
        [Authorize]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
