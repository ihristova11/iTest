using System;
using iTest.Data.Models;
using iTest.Data.Repository;
using iTest.Data.UnitsOfWork;
using iTest.Infrastructure.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace iTest.UnitTests.Services.User.UserTestService
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
            var userTestRepoMock = new Mock<IRepository<UserTest>>();

            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.User.Implementations.UserTestService(null, testRepoMock.Object, userTestRepoMock.Object, categoryRepoMock.Object, saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCategoryRepoIsNull()
        {
            var mappingProviderMock = new Mock<IMappingProvider>();
            var testRepoMock = new Mock<IRepository<Test>>();
            var saverMock = new Mock<ISaver>();
            var userTestRepoMock = new Mock<IRepository<UserTest>>();

            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.User.Implementations.UserTestService(mappingProviderMock.Object, testRepoMock.Object, userTestRepoMock.Object, null, saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenUserTestRepoIsNull()
        {
            var mappingProviderMock = new Mock<IMappingProvider>();
            var categoryRepoMock = new Mock<IRepository<Category>>();
            var saverMock = new Mock<ISaver>();
            var testRepoMock = new Mock<IRepository<Test>>();

            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.User.Implementations.UserTestService(mappingProviderMock.Object, testRepoMock.Object, null, categoryRepoMock.Object, saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenTestRepoIsNull()
        {
            var mappingProviderMock = new Mock<IMappingProvider>();
            var categoryRepoMock = new Mock<IRepository<Category>>();
            var saverMock = new Mock<ISaver>();
            var userTestRepoMock = new Mock<IRepository<UserTest>>();

            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.User.Implementations.UserTestService(mappingProviderMock.Object, null, userTestRepoMock.Object, categoryRepoMock.Object, saverMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var mappingProviderMock = new Mock<IMappingProvider>();
            var categoryRepoMock = new Mock<IRepository<Category>>();
            var userTestRepoMock = new Mock<IRepository<UserTest>>();
            var testRepoMock = new Mock<IRepository<Test>>();

            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.User.Implementations.UserTestService(mappingProviderMock.Object, testRepoMock.Object, userTestRepoMock.Object, categoryRepoMock.Object, null));
        }
    }
}
