//using System;
//using iTest.Data.Models;
//using iTest.Infrastructure.Providers;
//using iTest.Services.Data.Admin.Contracts;
//using iTest.Services.Data.User.Contracts;
//using iTest.Web.Areas.Admin.Controllers;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using NToastNotify;

//namespace iTest.UnitTests.Controllers.Admin.DashboardController
//{
//    [TestClass]
//    public class Constructor_Should
//    {
//        //private readonly IMappingProvider mapper;
//        //private readonly IAdminTestService tests;
//        //private readonly IUserTestService userTests;
//        //private readonly UserManager<User> userManager;

//        [TestMethod]
//        public void ThrowArgumentNullException_WhenMappingProviderIsNull()
//        {
//            var mappingProviderMock = new Mock<IMappingProvider>();
//            var testServiceMock = new Mock<IAdminTestService>();
//            var categoriesServiceMock = new Mock<IAdminCategoryService>();
//            var userTestServiceMock = new Mock<IUserTestService>();
//            var userManagerMock = new Mock<UserManager<User>>();

//            Assert.ThrowsException<ArgumentNullException>(() => new Web.Areas.Admin.Controllers.DashboardController(null, testServiceMock.Object, userManagerMock.Object));
//        }

//        //[TestMethod]
//        //public void ThrowArgumentNullException_WhenCategoryServiceIsNull()
//        //{
//        //    var mappingProviderMock = new Mock<IMappingProvider>();
//        //    var testServiceMock = new Mock<IAdminTestService>();
//        //    var toastrMock = new Mock<IToastNotification>();

//        //    Assert.ThrowsException<ArgumentNullException>(() => new AdminCategoriesController(testServiceMock.Object, null, mappingProviderMock.Object, toastrMock.Object));
//        //}

//        //[TestMethod]
//        //public void ThrowArgumentNullException_WhenTestServiceIsNull()
//        //{
//        //    var mappingProviderMock = new Mock<IMappingProvider>();
//        //    var categoriesServiceMock = new Mock<IAdminCategoryService>();
//        //    var toastrMock = new Mock<IToastNotification>();

//        //    Assert.ThrowsException<ArgumentNullException>(() => new AdminCategoriesController(null, categoriesServiceMock.Object, mappingProviderMock.Object, toastrMock.Object));
//        //}

//        //[TestMethod]
//        //public void ThrowArgumentNullException_WhenToastrIsNull()
//        //{
//        //    var mappingProviderMock = new Mock<IMappingProvider>();
//        //    var testServiceMock = new Mock<IAdminTestService>();
//        //    var categoriesServiceMock = new Mock<IAdminCategoryService>();

//        //    Assert.ThrowsException<ArgumentNullException>(() => new AdminCategoriesController(testServiceMock.Object, categoriesServiceMock.Object, mappingProviderMock.Object, null));
//        //}
//    }
//}
