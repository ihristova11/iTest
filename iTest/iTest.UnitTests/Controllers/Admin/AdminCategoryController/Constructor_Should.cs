using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using iTest.Web.Areas.Admin.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace iTest.UnitTests.Controllers.Admin.AdminCategoryController
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenMappingProviderIsNull()
        {
            var mappingProviderMock = new Mock<IMappingProvider>();
            var testServiceMock = new Mock<IAdminTestService>();
            var categoriesServiceMock = new Mock<IAdminCategoryService>(); ;

            Assert.ThrowsException<ArgumentNullException>(() => new AdminCategoriesController(testServiceMock.Object, categoriesServiceMock.Object, null));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCategoryServiceIsNull()
        {
            var mappingProviderMock = new Mock<IMappingProvider>();
            var testServiceMock = new Mock<IAdminTestService>();

            Assert.ThrowsException<ArgumentNullException>(() => new AdminCategoriesController(testServiceMock.Object, null, mappingProviderMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenTestServiceIsNull()
        {
            var mappingProviderMock = new Mock<IMappingProvider>();
            var categoriesServiceMock = new Mock<IAdminCategoryService>();

            Assert.ThrowsException<ArgumentNullException>(() => new AdminCategoriesController(null, categoriesServiceMock.Object, mappingProviderMock.Object));
        }
    }
}
