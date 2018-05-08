using System;
using iTest.Data.Models;
using iTest.Data.Repository;
using iTest.Data.UnitsOfWork;
using iTest.Infrastructure.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace iTest.UnitTests.Services.Admin.AdminTestService
{
    [TestClass]
    public class Constructor_Should
    {
        //private readonly IMappingProvider mapper;
        //private readonly IUserTestService<Test> tests;
        //private readonly IUserTestService<Question> questions;
        //private readonly IUserTestService<Category> categories;
        //private readonly IUserTestService<Answer> answers;
        //private readonly IUserTestService<UserTest> userTests;
        //private readonly ISaver saver;

        [TestMethod]
        public void ThrowArgumentNullException_WhenMappingProviderIsNull()
        {
            var categoryRepoMock = new Mock<IUserTestService<Category>>();
            var testRepoMock = new Mock<IUserTestService<Test>>();
            var saverMock = new Mock<ISaver>();
            var questionsRepoMock = new Mock<IUserTestService<Question>>();
            var answersRepoMock = new Mock<IUserTestService<Answer>>();
            var userTestRepoMock = new Mock<IUserTestService<UserTest>>();

            Assert.ThrowsException<ArgumentNullException>(() => new iTest.Services.Data.Admin.Implementations.AdminTestService(null, testRepoMock.Object, questionsRepoMock.Object, categoryRepoMock.Object, saverMock.Object, answersRepoMock.Object, userTestRepoMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenCategoryRepoIsNull()
        {
            //var categoryRepoMock = new Mock<IUserTestService<Category>>();
            var mappingMock = new Mock<IMappingProvider>();
            var testRepoMock = new Mock<IUserTestService<Test>>();
            var saverMock = new Mock<ISaver>();
            var questionsRepoMock = new Mock<IUserTestService<Question>>();
            var answersRepoMock = new Mock<IUserTestService<Answer>>();
            var userTestRepoMock = new Mock<IUserTestService<UserTest>>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                new iTest.Services.Data.Admin.Implementations.AdminTestService(mappingMock.Object, testRepoMock.Object,
                    questionsRepoMock.Object, null, saverMock.Object, answersRepoMock.Object,
                    userTestRepoMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenQuestionRepoIsNull()
        {
            var categoryRepoMock = new Mock<IUserTestService<Category>>();
            var mappingMock = new Mock<IMappingProvider>();
            var testRepoMock = new Mock<IUserTestService<Test>>();
            var saverMock = new Mock<ISaver>();
            //var questionsRepoMock = new Mock<IUserTestService<Question>>();
            var answersRepoMock = new Mock<IUserTestService<Answer>>();
            var userTestRepoMock = new Mock<IUserTestService<UserTest>>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                new iTest.Services.Data.Admin.Implementations.AdminTestService(mappingMock.Object, testRepoMock.Object,
                   null, categoryRepoMock.Object, saverMock.Object, answersRepoMock.Object,
                    userTestRepoMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenTestRepoIsNull()
        {
            var categoryRepoMock = new Mock<IUserTestService<Category>>();
            var mappingMock = new Mock<IMappingProvider>();
            //var testRepoMock = new Mock<IUserTestService<Test>>();
            var saverMock = new Mock<ISaver>();
            var questionsRepoMock = new Mock<IUserTestService<Question>>();
            var answersRepoMock = new Mock<IUserTestService<Answer>>();
            var userTestRepoMock = new Mock<IUserTestService<UserTest>>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                new iTest.Services.Data.Admin.Implementations.AdminTestService(mappingMock.Object, null,
                    questionsRepoMock.Object, categoryRepoMock.Object, saverMock.Object, answersRepoMock.Object,
                    userTestRepoMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var categoryRepoMock = new Mock<IUserTestService<Category>>();
            var mappingMock = new Mock<IMappingProvider>();
            var testRepoMock = new Mock<IUserTestService<Test>>();
            //var saverMock = new Mock<ISaver>();
            var questionsRepoMock = new Mock<IUserTestService<Question>>();
            var answersRepoMock = new Mock<IUserTestService<Answer>>();
            var userTestRepoMock = new Mock<IUserTestService<UserTest>>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                new iTest.Services.Data.Admin.Implementations.AdminTestService(mappingMock.Object, testRepoMock.Object,
                    questionsRepoMock.Object, categoryRepoMock.Object, null, answersRepoMock.Object,
                    userTestRepoMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenAnswerRepokIsNull()
        {
            var categoryRepoMock = new Mock<IUserTestService<Category>>();
            var mappingMock = new Mock<IMappingProvider>();
            var testRepoMock = new Mock<IUserTestService<Test>>();
            var saverMock = new Mock<ISaver>();
            var questionsRepoMock = new Mock<IUserTestService<Question>>();
            //var answersRepoMock = new Mock<IUserTestService<Answer>>();
            var userTestRepoMock = new Mock<IUserTestService<UserTest>>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                new iTest.Services.Data.Admin.Implementations.AdminTestService(mappingMock.Object, testRepoMock.Object,
                    questionsRepoMock.Object, categoryRepoMock.Object, saverMock.Object, null,
                    userTestRepoMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenUserTestRepokIsNull()
        {
            var categoryRepoMock = new Mock<IUserTestService<Category>>();
            var mappingMock = new Mock<IMappingProvider>();
            var testRepoMock = new Mock<IUserTestService<Test>>();
            var saverMock = new Mock<ISaver>();
            var questionsRepoMock = new Mock<IUserTestService<Question>>();
            var answersRepoMock = new Mock<IUserTestService<Answer>>();
            //var userTestRepoMock = new Mock<IUserTestService<UserTest>>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                new iTest.Services.Data.Admin.Implementations.AdminTestService(mappingMock.Object, testRepoMock.Object,
                    questionsRepoMock.Object, categoryRepoMock.Object, saverMock.Object, answersRepoMock.Object,
                    null));
        }
    }
}
