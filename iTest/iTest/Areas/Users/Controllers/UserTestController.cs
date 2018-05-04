using iTest.Data.Models;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using iTest.Web.Areas.Users.Controllers.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
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
            this.testsServices = testsServices;
            this.categories = categories;
            this.mapper = mapper;
            this.userManager = userManager;
            this.toastr = toastr;
        }

        public async Task<IActionResult> All()
            => await Task.Run(() => View());

        public async Task<IActionResult> AllByCategoryAsync(Category category)
            => await Task.Run(() => View(category.Name));
    }
}