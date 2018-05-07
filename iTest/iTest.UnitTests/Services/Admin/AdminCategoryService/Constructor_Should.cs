using iTest.Data.Models;
using iTest.Data.Repository;
using iTest.Data.UnitsOfWork;
using iTest.Infrastructure.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace iTest.UnitTests.Services.Admin.AdminCategoryService
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenMappingProviderIsNull()
        {
            var categoryRepoMock = new Mock<IUserTestService<Category>>();
            var testRepoMock = new Mock<IUserTestService<Test>>();
            var saverMock = new Mock<ISaver>();

            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.Admin.Implementations.AdminCategoryService(null, categoryRepoMock.Object, testRepoMock.Object, saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCategoryRepoIsNull()
        {
            var mappingProviderMock = new Mock<IMappingProvider>();
            var testRepoMock = new Mock<IUserTestService<Test>>();
            var saverMock = new Mock<ISaver>();

            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.Admin.Implementations.AdminCategoryService(mappingProviderMock.Object, null, testRepoMock.Object, saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenTestRepoIsNull()
        {
            var categoryRepoMock = new Mock<IUserTestService<Category>>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.Admin.Implementations.AdminCategoryService(mappingProviderMock.Object, categoryRepoMock.Object, null, saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var testRepoMock = new Mock<IUserTestService<Test>>();
            var categoryRepoMock = new Mock<IUserTestService<Category>>();
            var mappingProviderMock = new Mock<IMappingProvider>();

            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.Admin.Implementations.AdminCategoryService(mappingProviderMock.Object, categoryRepoMock.Object, testRepoMock.Object, null));
        }
    }
}
