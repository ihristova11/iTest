using System;
using System.Collections.Generic;
using System.Linq;
using iTest.Data.Models;
using iTest.Data.Repository;
using iTest.Data.UnitsOfWork;
using iTest.DTO;
using iTest.Infrastructure.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace iTest.UnitTests.Services.Admin.AdminTestService
{
    [TestClass]
    public class AllByAuthor_Should
    {
        [TestMethod]
        public void ReturnCorrectNumberOfDtos_WhenCollectionIsNotNull()
        {
            //Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();
            var testsRepoMock = new Mock<IUserTestService<Test>>();
            var questionRepoMock = new Mock<IUserTestService<Question>>();
            var categoryRepoMock = new Mock<IUserTestService<Category>>();
            var answerRepoMock = new Mock<IUserTestService<Answer>>();
            var userTestsRepoMock = new Mock<IUserTestService<UserTest>>();

            var author = new Data.Models.User() {UserName = "a@a.com", Id = "1"};
            var data = new List<Test>()
            {
                new Test {Name = "Test1", Author = author, AuthorId = "1"},
                new Test {Name = "Test2", Author = author, AuthorId = "1"},
                new Test {Name = "Test3", Author = author, AuthorId = "1"}
            }.AsQueryable();

            testsRepoMock.Setup(x => x.All).Returns(data);

            var dtoAuthor = new UserDTO() {UserName = "a@a.com", Id = "1"};
            var mapperData = new List<TestDTO>()
            {
                new TestDTO {Name = "Test1", Author = dtoAuthor, AuthorId = "1"},
                new TestDTO {Name = "Test2", Author = dtoAuthor, AuthorId = "1"},
                new TestDTO {Name = "Test3", Author = dtoAuthor, AuthorId = "1"}
            };

            mapperMock.Setup(m => m.ProjectTo<TestDTO>(It.IsAny<IQueryable<Test>>()))
                .Returns(new List<TestDTO>(mapperData).AsQueryable);
            var adminService = new iTest.Services.Data.Admin.Implementations.AdminTestService(mapperMock.Object,
                testsRepoMock.Object, questionRepoMock.Object, categoryRepoMock.Object, saverMock.Object,
                answerRepoMock.Object, userTestsRepoMock.Object);
            data.ToList();

            //Act
            var tests = adminService.AllByAuthor(author.Id);

            //Assert
            Assert.AreEqual(data.Count(), tests.Count());
        }

        [TestMethod]
        public void ReturnNotNull_WhenCollectionIsNotNull()
        {
            //Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();
            var testsRepoMock = new Mock<IUserTestService<Test>>();
            var questionRepoMock = new Mock<IUserTestService<Question>>();
            var categoryRepoMock = new Mock<IUserTestService<Category>>();
            var answerRepoMock = new Mock<IUserTestService<Answer>>();
            var userTestsRepoMock = new Mock<IUserTestService<UserTest>>();

            var author = new Data.Models.User() { UserName = "a@a.com", Id = "1" };
            var data = new List<Test>()
            {
                new Test {Name = "Test1", Author = author, AuthorId = "1"},
                new Test {Name = "Test2", Author = author, AuthorId = "1"},
                new Test {Name = "Test3", Author = author, AuthorId = "1"}
            }.AsQueryable();

            testsRepoMock.Setup(x => x.All).Returns(data);

            var dtoAuthor = new UserDTO() { UserName = "a@a.com", Id = "1" };
            var mapperData = new List<TestDTO>()
            {
                new TestDTO {Name = "Test1", Author = dtoAuthor, AuthorId = "1"},
                new TestDTO {Name = "Test2", Author = dtoAuthor, AuthorId = "1"},
                new TestDTO {Name = "Test3", Author = dtoAuthor, AuthorId = "1"}
            };

            mapperMock.Setup(m => m.ProjectTo<TestDTO>(It.IsAny<IQueryable<Test>>()))
                .Returns(new List<TestDTO>(mapperData).AsQueryable);
            var adminService = new iTest.Services.Data.Admin.Implementations.AdminTestService(mapperMock.Object,
                testsRepoMock.Object, questionRepoMock.Object, categoryRepoMock.Object, saverMock.Object,
                answerRepoMock.Object, userTestsRepoMock.Object);
            data.ToList();

            //Act
            var tests = adminService.AllByAuthor(author.Id);

            //Assert
            Assert.IsNotNull(tests);
        }

        [TestMethod]
        public void ReturnIEnumerableOfTestDto_WhenCollectionIsNotNull()
        {
            //Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();
            var testsRepoMock = new Mock<IUserTestService<Test>>();
            var questionRepoMock = new Mock<IUserTestService<Question>>();
            var categoryRepoMock = new Mock<IUserTestService<Category>>();
            var answerRepoMock = new Mock<IUserTestService<Answer>>();
            var userTestsRepoMock = new Mock<IUserTestService<UserTest>>();

            var author = new Data.Models.User() { UserName = "a@a.com", Id = "1" };
            var data = new List<Test>()
            {
                new Test {Name = "Test1", Author = author, AuthorId = "1"},
                new Test {Name = "Test2", Author = author, AuthorId = "1"},
                new Test {Name = "Test3", Author = author, AuthorId = "1"}
            }.AsQueryable();

            testsRepoMock.Setup(x => x.All).Returns(data);

            var dtoAuthor = new UserDTO() { UserName = "a@a.com", Id = "1" };
            var mapperData = new List<TestDTO>()
            {
                new TestDTO {Name = "Test1", Author = dtoAuthor, AuthorId = "1"},
                new TestDTO {Name = "Test2", Author = dtoAuthor, AuthorId = "1"},
                new TestDTO {Name = "Test3", Author = dtoAuthor, AuthorId = "1"}
            };

            mapperMock.Setup(m => m.ProjectTo<TestDTO>(It.IsAny<IQueryable<Test>>()))
                .Returns(new List<TestDTO>(mapperData).AsQueryable);
            var adminService = new iTest.Services.Data.Admin.Implementations.AdminTestService(mapperMock.Object,
                testsRepoMock.Object, questionRepoMock.Object, categoryRepoMock.Object, saverMock.Object,
                answerRepoMock.Object, userTestsRepoMock.Object);
            data.ToList();

            //Act
            var tests = adminService.AllByAuthor(author.Id);

            //Assert
            Assert.IsInstanceOfType(tests, typeof(IEnumerable<TestDTO>));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenAuhotIdParameterIsNull()
        {
            //Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();
            var testsRepoMock = new Mock<IUserTestService<Test>>();
            var questionRepoMock = new Mock<IUserTestService<Question>>();
            var categoryRepoMock = new Mock<IUserTestService<Category>>();
            var answerRepoMock = new Mock<IUserTestService<Answer>>();
            var userTestsRepoMock = new Mock<IUserTestService<UserTest>>();

            var adminService = new iTest.Services.Data.Admin.Implementations.AdminTestService(mapperMock.Object,
                testsRepoMock.Object, questionRepoMock.Object, categoryRepoMock.Object, saverMock.Object,
                answerRepoMock.Object, userTestsRepoMock.Object);

            Assert.ThrowsException<ArgumentException>(() => adminService.AllByAuthor(null));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenAuhotIdParameterIsEmpty()
        {
            //Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();
            var testsRepoMock = new Mock<IUserTestService<Test>>();
            var questionRepoMock = new Mock<IUserTestService<Question>>();
            var categoryRepoMock = new Mock<IUserTestService<Category>>();
            var answerRepoMock = new Mock<IUserTestService<Answer>>();
            var userTestsRepoMock = new Mock<IUserTestService<UserTest>>();

            var adminService = new iTest.Services.Data.Admin.Implementations.AdminTestService(mapperMock.Object,
                testsRepoMock.Object, questionRepoMock.Object, categoryRepoMock.Object, saverMock.Object,
                answerRepoMock.Object, userTestsRepoMock.Object);

            Assert.ThrowsException<ArgumentException>(() => adminService.AllByAuthor(String.Empty));
        }

        [TestMethod]
        public void Invoke_Mapper_ProjectTo()
        {
            //Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var saverMock = new Mock<ISaver>();
            var testsRepoMock = new Mock<IUserTestService<Test>>();
            var questionRepoMock = new Mock<IUserTestService<Question>>();
            var categoryRepoMock = new Mock<IUserTestService<Category>>();
            var answerRepoMock = new Mock<IUserTestService<Answer>>();
            var userTestsRepoMock = new Mock<IUserTestService<UserTest>>();

            var author = new Data.Models.User() { UserName = "a@a.com", Id = "1" };
            var data = new List<Test>()
            {
                new Test { Name = "Test1", Author = author, AuthorId = "1"},
                new Test { Name = "Test2", Author = author, AuthorId = "1"},
                new Test { Name = "Test3", Author = author, AuthorId = "1"}
            }.AsQueryable();

            testsRepoMock.Setup(x => x.All).Returns(data);

            var dtoAuthor = new UserDTO() { UserName = "a@a.com", Id = "1" };
            var mapperData = new List<TestDTO>()
            {
                new TestDTO { Name = "Test1", Author = dtoAuthor, AuthorId = "1"},
                new TestDTO { Name = "Test2", Author = dtoAuthor, AuthorId = "1"},
                new TestDTO { Name = "Test3", Author = dtoAuthor, AuthorId = "1"}
            };

            mapperMock.Setup(m => m.ProjectTo<TestDTO>(It.IsAny<IQueryable<Test>>())).Returns(new List<TestDTO>(mapperData).AsQueryable);
            var adminService = new iTest.Services.Data.Admin.Implementations.AdminTestService(mapperMock.Object,
                testsRepoMock.Object, questionRepoMock.Object, categoryRepoMock.Object, saverMock.Object,
                answerRepoMock.Object, userTestsRepoMock.Object);
            data.ToList();

            //Act
            var tests = adminService.AllByAuthor(author.Id);

            //Assert
            mapperMock.Verify(x => x.ProjectTo<TestDTO>(It.IsAny<IQueryable<Test>>()), Times.Once);

        }
    }
}
