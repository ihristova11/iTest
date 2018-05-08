using iTest.Data.Models;
using iTest.Data.Models.Enums;
using iTest.Data.Repository;
using iTest.Data.UnitsOfWork;
using iTest.DTO;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.User.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iTest.Services.Data.User.Implementations
{
    public class UserTestService : IUserTestService
    {
        private readonly IMappingProvider mapper;
        private readonly IUserTestService<Test> tests;
        private readonly IUserTestService<UserTest> userTests;
        private readonly IUserTestService<Category> categories;
        private readonly ISaver saver;

        public UserTestService(IMappingProvider mapper, IUserTestService<Test> tests, IUserTestService<UserTest> userTests, IUserTestService<Category> categories, ISaver saver)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.tests = tests ?? throw new ArgumentNullException(nameof(tests));
            this.userTests = userTests ?? throw new ArgumentNullException(nameof(userTests));
            this.categories = categories ?? throw new ArgumentNullException(nameof(categories));
            this.saver = saver ?? throw new ArgumentNullException(nameof(saver));
        }

        public IEnumerable<TestDTO> All()
        {
            var allTests = this.tests.All;

            if (allTests == null)
            {
                throw new ArgumentException("No tests were found!");
            }

            return this.mapper.ProjectTo<TestDTO>(allTests);
        }

        public IEnumerable<TestDTO> AllByCategory(string category)
        {
            var allTests = this.tests
                                 .All
                                 .Where(x => x.Category.Name == category);

            if (allTests == null)
            {
                throw new ArgumentException("No tests were found!");
            }

            return this.mapper.ProjectTo<TestDTO>(allTests);
        }

        public TestDTO FindById(int id)
        {
            var test = this.tests
                            .All
                            .Where(t => t.Id == id)
                            .Include(c => c.Category)
                            .Include(q => q.Questions)
                            .ThenInclude(a => a.Answers)
                            .FirstOrDefault();

            if (test == null)
            {
                throw new ArgumentException($"Test with name:{id} couldn't be found!");
            }

            return this.mapper.MapTo<TestDTO>(test);
        }

        public UserTestDTO MapStartedTest(string userId, int testId)
        {
            var test = this.tests.All.FirstOrDefault(t => t.Id == testId);

            if (test == null)
            {
                throw new ArgumentException($"Test with id:{testId} couldn't be found!");
            }

            var dto = mapper.MapTo<UserTestDTO>(test);

            return dto;
        }

        public void SaveResult(UserTestDTO dto)
        {
            var test = this.tests.All.FirstOrDefault(x => x.Id == dto.TestId);

            if (test == null)
            {
                throw new ArgumentException("Test was not found!");
            }

            var userTest = this.mapper.MapTo<UserTestDTO>(test);

            // map props
            userTest.UserId = dto.UserId;
            userTest.TestId = dto.TestId;
            userTest.RequestedTime = dto.RequestedTime;
            userTest.ExecutionTime = dto.ExecutionTime;
            userTest.ResultStatus = dto.ResultStatus;

            var domainTest = this.mapper.MapTo<UserTest>(userTest);

            this.userTests.Add(domainTest);

            this.saver.SaveChanges();
        }

        public ResultStatus GetTestResultByUser(string userId, int testId)
        {
            var test = this.userTests.All.FirstOrDefault(x => x.UserId == userId && x.TestId == testId);

            return test.ResultStatus;
        }
    }
}
