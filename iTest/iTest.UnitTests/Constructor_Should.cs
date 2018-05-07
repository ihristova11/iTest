//using System;
//using iTest.Data.Models;
//using iTest.Infrastructure.Providers;
//using iTest.Services.Data.Admin.Contracts;
//using iTest.Web.Areas.Admin.Controllers;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;

//namespace iTest.UnitTests
//{
//    [TestClass]
//    public class Constructor_Should
//    {
//        [TestMethod]
//        public void ThrowArgumentNullException_WhenTestServiceIsNull()
//        {
//            var adminCategoryServiceMock = new Mock<IAdminCategoryService>();
//            var mappingProviderMock = new Mock<IMappingProvider>();
//            var userManagerMock = new Mock<UserManager<User>>();

//            Assert.ThrowsException<ArgumentNullException>(() => new ManageTestController(null, adminCategoryServiceMock.Object, mappingProviderMock.Object, userManagerMock.Object));
//        }
//    }
//}