using iTest.Data.Models;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.User.Contracts;
using iTest.Web.Areas.Users.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace iTest.UnitTests.Controllers.Users.DashboardControllerTests
{
    [TestClass]
    public class Constructor_Should
    {

        [TestMethod]
        public void ThrowArgumentNullException_WhenMappingProviderIsNull()
        {
            var categoriesServiceMock = new Mock<IUserCategoryService>();
            var userTestServiceMock = new Mock<IUserTestService>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userManagerMock = new Mock<UserManager<User>>(MockBehavior.Default);


            Assert.ThrowsException<ArgumentNullException>(() => new DashboardController(userTestServiceMock.Object, categoriesServiceMock.Object, null, userManagerMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCategoriesServiceIsNull()
        {
            var categoriesServiceMock = new Mock<IUserCategoryService>();
            var userTestServiceMock = new Mock<IUserTestService>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userManagerMock = new Mock<UserManager<User>>();

            Assert.ThrowsException<ArgumentNullException>(() => new DashboardController(userTestServiceMock.Object, null, mappingProviderMock.Object, userManagerMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenTestServiceIsNull()
        {
            var categoriesServiceMock = new Mock<IUserCategoryService>();
            var userTestServiceMock = new Mock<IUserTestService>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userManagerMock = new Mock<UserManager<User>>();

            Assert.ThrowsException<ArgumentNullException>(() => new DashboardController(null, categoriesServiceMock.Object, mappingProviderMock.Object, userManagerMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenUserManagerIsNull()
        {
            var categoriesServiceMock = new Mock<IUserCategoryService>();
            var userTestServiceMock = new Mock<IUserTestService>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userManagerMock = new Mock<UserManager<User>>();

            Assert.ThrowsException<ArgumentNullException>(() => new DashboardController(userTestServiceMock.Object, categoriesServiceMock.Object, mappingProviderMock.Object, null));
        }
    }
}
