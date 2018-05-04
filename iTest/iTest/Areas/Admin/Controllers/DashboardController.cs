using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iTest.Data.Models;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using iTest.Web.Areas.Admin.Controllers.Abstract;
using iTest.Web.Areas.Admin.Models.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace iTest.Web.Areas.Admin.Controllers
{
    public class DashboardController : AdminController
    {
        private readonly IMappingProvider mapper;
        private readonly IAdminTestService tests;
        private readonly IResultService resultService;
        private readonly UserManager<User> userManager;

        public DashboardController(IMappingProvider mapper, IAdminTestService tests, IResultService resultService, UserManager<User> userManager)
        {
            this.mapper = mapper ?? throw new ArgumentNullException("Mapper can not be null");
            this.tests = tests ?? throw new ArgumentNullException("Tests service cannot be null");
            this.resultService = resultService ?? throw new ArgumentNullException("Result service cannot be null");
            this.userManager = userManager ?? throw new ArgumentNullException("User manager cannot be null");
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View("Index"); //, model);
        }
    }
}