//using System;
//using iTest.Data.Models;
//using iTest.Data.Repository;
//using iTest.Data.UnitsOfWork;
//using iTest.Infrastructure.Providers;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;

//namespace iTest.UnitTests.Services.Admin.AdminTestService
//{
//    [TestClass]
//    public class Constructor_Should
//    {
//        [TestMethod]
//        public void ThrowArgumentNullException_WhenMappingProviderIsNull()
//        {
//            var categoryRepoMock = new Mock<IRepository<Category>>();
//            var testRepoMock = new Mock<IRepository<Test>>();
//            var saverMock = new Mock<ISaver>();
//            var questionsRepoMock = new Mock<IRepository<Question>>();

//            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.Admin.Implementations.AdminTestService(null,  testRepoMock.Object, questionsRepoMock.Object, categoryRepoMock.Object, saverMock.Object));
//        }

//        [TestMethod]
//        public void ThrowArgumentNullException_WhenCategoryRepoIsNull()
//        {
//            var mappingProviderMock = new Mock<IMappingProvider>();
//            var categoryRepoMock = new Mock<IRepository<Category>>();
//            var saverMock = new Mock<ISaver>();
//            var questionsRepoMock = new Mock<IRepository<Question>>();

//            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.Admin.Implementations.AdminTestService(mappingProviderMock.Object, null, questionsRepoMock.Object, categoryRepoMock.Object, saverMock.Object));
//        }

//        [TestMethod]
//        public void ThrowArgumentNullException_WhenQuestionRepoIsNull()
//        {
//            var mappingProviderMock = new Mock<IMappingProvider>();
//            var categoryRepoMock = new Mock<IRepository<Category>>();
//            var saverMock = new Mock<ISaver>();
//            var testRepoMock = new Mock<IRepository<Test>>();

//            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.Admin.Implementations.AdminTestService(mappingProviderMock.Object, testRepoMock.Object, null, categoryRepoMock.Object, saverMock.Object));
//        }

//        [TestMethod]
//        public void ThrowArgumentNullException_WhenTestRepoIsNull()
//        {
//            var mappingProviderMock = new Mock<IMappingProvider>();
//            var categoryRepoMock = new Mock<IRepository<Category>>();
//            var saverMock = new Mock<ISaver>();
//            var questionsRepoMock = new Mock<IRepository<Question>>();

//            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.Admin.Implementations.AdminTestService(mappingProviderMock.Object, null, questionsRepoMock.Object, categoryRepoMock.Object, saverMock.Object));
//        }

//        [TestMethod]
//        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
//        {
//            var mappingProviderMock = new Mock<IMappingProvider>();
//            var testRepoMock = new Mock<IRepository<Test>>();
//            var categoryRepoMock = new Mock<IRepository<Category>>();
//            var questionsRepoMock = new Mock<IRepository<Question>>();

//            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.Admin.Implementations.AdminTestService(mappingProviderMock.Object, testRepoMock.Object, questionsRepoMock.Object, categoryRepoMock.Object, null));
//        }
//    }
//}
