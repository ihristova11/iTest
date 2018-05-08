using System;
using iTest.Data.Models;
using iTest.Data.Repository;
using iTest.Data.UnitsOfWork;
using iTest.Infrastructure.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace iTest.UnitTests.Services.User.UserCategoryService
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenMappingProviderIsNull()
        {
            var categoryRepoMock = new Mock<IRepository<Category>>();
            var testRepoMock = new Mock<IRepository<Test>>();
            var saverMock = new Mock<ISaver>();

            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.User.Implementations.UserCategoryService(null, categoryRepoMock.Object, testRepoMock.Object, saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCategoryRepoIsNull()
        {
            var mappingProviderMock = new Mock<IMappingProvider>();
            var testRepoMock = new Mock<IRepository<Test>>();
            var saverMock = new Mock<ISaver>();

            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.User.Implementations.UserCategoryService(mappingProviderMock.Object, null, testRepoMock.Object, saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenTestRepoIsNull()
        {
            var categoryRepoMock = new Mock<IRepository<Category>>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();

            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.User.Implementations.UserCategoryService(mappingProviderMock.Object, categoryRepoMock.Object, null, saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var testRepoMock = new Mock<IRepository<Test>>();
            var categoryRepoMock = new Mock<IRepository<Category>>();
            var mappingProviderMock = new Mock<IMappingProvider>();

            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.User.Implementations.UserCategoryService(mappingProviderMock.Object, categoryRepoMock.Object, testRepoMock.Object, null));
        }
    }
}
