using System;
using iTest.Data.Models;
using iTest.Data.Repository;
using iTest.Data.UnitsOfWork;
using iTest.Infrastructure.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace iTest.UnitTests.Services.Admin.ResultService
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenMappingProviderIsNull()
        {
            var saverMock = new Mock<ISaver>();
            var userTestRepoMock = new Mock<IRepository<UserTest>>();

            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.Admin.Implementations.ResultService(saverMock.Object, null, userTestRepoMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var mappingProviderMock = new Mock<IMappingProvider>();
            var userTestRepoMock = new Mock<IRepository<UserTest>>();

            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.Admin.Implementations.ResultService(null, mappingProviderMock.Object, userTestRepoMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenUserTestRepoIsNull()
        {
            var saverMock = new Mock<ISaver>();
            var mappingProviderMock = new Mock<IMappingProvider>();
            

            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.Admin.Implementations.ResultService(saverMock.Object, mappingProviderMock.Object, null));
        }
    }
}
