using iTest.Data.Models.Implementations;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using iTest.Web.Areas.Users.Controllers.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Threading.Tasks;

namespace iTest.Web.Areas.Users.Controllers
{
    public class UserTestController : UserController
    {
        private readonly IAdminTestService testsServices;
        private readonly IAdminCategoryService categories;
        private readonly IMappingProvider mapper;
        private readonly UserManager<User> userManager;
        private readonly IToastNotification toastr;

        public UserTestController(IAdminTestService testsServices, IAdminCategoryService categories, IMappingProvider mapper, UserManager<User> userManager, IToastNotification toastr)
        {
            this.testsServices = testsServices ?? throw new ArgumentNullException(nameof(testsServices));
            this.categories = categories ?? throw new ArgumentNullException(nameof(categories));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.toastr = toastr ?? throw new ArgumentNullException(nameof(toastr));
        }

        public async Task<IActionResult> AllAsync()
            => await Task.Run(() => View());

        public async Task<IActionResult> AllByCategoryAsync(Category category)
            => await Task.Run(() => View(category.Name));
    }
}