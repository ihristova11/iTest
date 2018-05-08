using iTest.Data.Models;
using iTest.Data.Repository;
using iTest.Data.UnitsOfWork;
using iTest.DTO;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTest.Data.Models.Enums;

namespace iTest.Services.Data.Admin.Implementations
{
    public class AdminTestService : IAdminTestService
    {
        private readonly IMappingProvider mapper;
        private readonly IUserTestService<Test> tests;
        private readonly IUserTestService<Question> questions;
        private readonly IUserTestService<Category> categories;
        private readonly IUserTestService<Answer> answers;
        private readonly IUserTestService<UserTest> userTests;
        private readonly ISaver saver;

        public AdminTestService(IMappingProvider mapper, IUserTestService<Test> tests, IUserTestService<Question> questions, IUserTestService<Category> categories, ISaver saver, IUserTestService<Answer> answers, IUserTestService<UserTest> userTests)
        {
            this.mapper = mapper ?? throw new ArgumentNullException();
            this.tests = tests ?? throw new ArgumentNullException();
            this.questions = questions ?? throw new ArgumentNullException();
            this.saver = saver ?? throw new ArgumentNullException();
            this.answers = answers ?? throw new ArgumentNullException();
            this.userTests = userTests ?? throw new ArgumentNullException(nameof(userTests));
            this.categories = categories ?? throw new ArgumentNullException();
        }

        public IEnumerable<TestDTO> AllByAuthor(string authorId)
        {
            if (string.IsNullOrEmpty(authorId))
            {
                throw new ArgumentException("AuthorId cannot be null");
            }
            var allTests = this.tests
                                  .All
                                  .Include(x => x.Author)
                                  .Where(x => x.AuthorId == authorId);

            return this.mapper.ProjectTo<TestDTO>(allTests);
        }

        public IEnumerable<TestDTO> All()
        {
            var allTests = this.tests
                .All;

            return this.mapper.ProjectTo<TestDTO>(allTests);
        }

        public void PublishExistingTest(int id)
        {
            var test = this.tests.All
                .Where(t => t.Status != Status.Published && t.Id == id)
                .Include(q => q.Questions)
                .ThenInclude(a => a.Answers)
                .FirstOrDefault();

            if (!test.Questions.Any())
            {
                throw new InvalidTestException("Cannot publish a test with no questions!");
            }
            else
            {
                foreach (var question in test.Questions)
                {
                    if (question.Answers.Count < 2)
                    {
                        throw new InvalidTestException("Cannot publish a test with a question with less than 2 answers!");
                    }
                }
            }

            if (test != null)
            {
                test.Status = Status.Published;

                tests.Update(test);
                saver.SaveChanges();
            }
        }

        public async Task<TestDTO> FindByIdAsync(int id)
        {
            var test = await this.tests
                                  .All
                                  .Include(x => x.Author)
                                  .FirstOrDefaultAsync(x => x.Id == id);

            if (test == null)
            {
                throw new ArgumentException($"Test with id:{id} couldn't be found!");
            }

            return this.mapper.MapTo<TestDTO>(test);
        }

        public void Create(TestDTO dto)
        {
            var model = this.mapper.MapTo<Test>(dto);
            model.Category = this.categories.All.SingleOrDefault(x => x.Name == dto.CategoryName);
            this.tests.Add(model);
            this.saver.SaveChanges();
        }

        // todo GET RANDOM TEST

        public async Task UpdateAsync(TestDTO dto)
        {
            var test = await this.tests.All.SingleOrDefaultAsync(x => x.Id == dto.Id);

            if (test == null)
            {
                throw new ArgumentException($"{dto.Name} was not found!");
            }

            // do not map! otherwise a new instance will be created in db
            //test.Name = dto.Name;
            //test.Category = test.Category;
            //test.Status = dto.Status;
            //test.RequestedTime = dto.RequestedTime;
            //test.Questions = dto.Questions;
            //test.Results = dto.Results;

            this.tests.Update(test);
            this.saver.SaveChangesAsync();
        }

        public void Disable(int id)
        {
            var test = this.tests.All
                .FirstOrDefault(t => t.Status != Status.Disabled && t.Id == id);

            //var usersTest = this.userTests.All
            //    .Where(ut => ut.StartedOn + ut.RequestedTime > DateTime.Now.AddSeconds(10));

            //if (usersTest == null)
            //{
            //    test.Status = Status.Draft;

            //    this.tests.Update(test);
            //    saver.SaveChanges();
            //}
            //else
            if (test != null)
            {
                test.Status = Status.Draft;

                this.tests.Update(test);
                saver.SaveChanges();
            }
            else
            {
                throw new InvalidTestException("Cannot set test status as Draft cause it been used right now by users.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var test = await this.tests.All.SingleOrDefaultAsync(x => x.Id == id);

            if (test == null)
            {
                throw new ArgumentException($"Test with id:{id} was not found!");
            }

            this.tests.Delete(test);

            foreach (var question in test.Questions)
            {
                foreach (var answer in question.Answers)
                {
                    this.answers.Delete(answer);
                }
                this.questions.Delete(question);
            }

            this.saver.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await this.tests.All.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await this.tests.All.AnyAsync(x => x.Name == name);
        }
    }
}
