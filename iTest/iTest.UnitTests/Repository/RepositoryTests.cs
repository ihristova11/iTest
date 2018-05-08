using iTest.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using iTest.Data;
using iTest.Data.Models;
using iTest.Data.Repository;

namespace DataTests.Repository
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void RepoAllWithoutDeleted_ReturnsCorrect()
        {
            // Arrange
            //var stubDateProvider = new Mock<IRepoTimeProvider>();
            var options = new DbContextOptionsBuilder<iTestDbContext>()
            .UseInMemoryDatabase(databaseName: "RepoAllWithoutDeleted_ReturnsCorrect")
            .Options;
            var stubContext = new iTestDbContext(options);
            var stubRepo = new EfRepository<Answer>(stubContext);//, stubDateProvider.Object);

            stubRepo.Add(new Answer() { IsCorrect = true });
            stubRepo.Add(new Answer() { IsCorrect = false });
            stubRepo.Add(new Answer() { IsCorrect = false });
            stubRepo.Add(new Answer() { IsCorrect = true, IsDeleted = true });
            stubRepo.Add(new Answer() { IsCorrect = false, IsDeleted = true });
            stubRepo.Add(new Answer() { IsCorrect = false, IsDeleted = true });
            stubContext.SaveChanges();

            //act
            var foundAnswers = stubRepo.All;

            //assert
            Assert.AreEqual(3, foundAnswers.Count());
            Assert.AreEqual(1, foundAnswers.Where(x => x.IsCorrect == true).Count());
            Assert.AreEqual(2, foundAnswers.Where(x => x.IsCorrect == false).Count());
        }

        [TestMethod]
        public void RepoAllWithDeletedOnes_ReturnsCorrect()
        {
            // Arrange
            //var stubDateProvider = new Mock<IRepoTimeProvider>();
            var options = new DbContextOptionsBuilder<iTestDbContext>()
            .UseInMemoryDatabase(databaseName: "RepoAllWithDeletedOnes_ReturnsCorrect")
            .Options;
            var stubContext = new iTestDbContext(options);
            var stubRepo = new EfRepository<Answer>(stubContext);//, stubDateProvider.Object);

            stubRepo.Add(new Answer() { Description = "da", IsCorrect = true });
            stubRepo.Add(new Answer() { Description = "nonono", IsCorrect = false });
            stubRepo.Add(new Answer() { Description = "dadada", IsCorrect = false, IsDeleted = true });
            stubRepo.Add(new Answer() { Description = "dada", IsCorrect = false });
            stubRepo.Add(new Answer() { Description = "nono", IsCorrect = true, IsDeleted = true });
            stubRepo.Add(new Answer() { Description = "no", IsCorrect = false, IsDeleted = true });
            stubContext.SaveChanges();

            //act
            var foundAnswers = stubRepo.AllAndDeleted;

            //assert
            Assert.AreEqual(6, foundAnswers.Count());
            Assert.AreEqual(2, foundAnswers.Where(x => x.IsCorrect == true).Count());
            Assert.AreEqual(4, foundAnswers.Where(x => x.IsCorrect == false).Count());
        }                                                

        [TestMethod]
        public void RepoAdd_Adds()
        {
            // Arrange
            //var stubDateProvider = new Mock<IRepoTimeProvider>();
            var options = new DbContextOptionsBuilder<iTestDbContext>()
            .UseInMemoryDatabase(databaseName: "RepoAdd_Adds")
            .Options;
            var stubContext = new iTestDbContext(options);
            var stubRepo = new EfRepository<Answer>(stubContext);//, stubDateProvider.Object);
            var expectedCount = 1;
            var answer = new Answer() { Description = "nonono" };
            stubRepo.Add(answer);

            stubContext.SaveChanges();

            //act
            var foundAnswers = stubRepo.All;

            //assert
            Assert.AreEqual(expectedCount, foundAnswers.Count());
        }
        [TestMethod]
        public void Delete_SetsDeletedToTrue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<iTestDbContext>()
            .UseInMemoryDatabase(databaseName: "Delete_SetsDeletedToTrue")
            .Options;
            var stubContext = new iTestDbContext(options);
            var stubRepo = new EfRepository<Answer>(stubContext);
            var answerToBeDeteletd = new Answer() { Description = "no" };

            //act
            stubRepo.Add(answerToBeDeteletd);
            stubContext.SaveChanges();
            stubRepo.Delete(answerToBeDeteletd);
            stubContext.SaveChanges();
            var foundDeletedAnswer = stubRepo.AllAndDeleted.First();

            //assert
            Assert.AreEqual(true, foundDeletedAnswer.IsDeleted);
        }

        [TestMethod]
        public void Delete_RemovesEntityFromRepoAll()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<iTestDbContext>()
            .UseInMemoryDatabase(databaseName: "Delete_RemovesEntityFromRepoAll")
            .Options;
            var stubContext = new iTestDbContext(options);
            var stubRepo = new EfRepository<Answer>(stubContext);
            var answerToBeDeteletd = new Answer() { Description = "nono" };

            //act
            stubRepo.Add(answerToBeDeteletd);
            stubContext.SaveChanges();
            stubRepo.Delete(answerToBeDeteletd);
            stubContext.SaveChanges();

            //assert
            Assert.AreEqual(0, stubRepo.All.Count());
            Assert.AreEqual(1, stubRepo.AllAndDeleted.Count());
        }
    }
}