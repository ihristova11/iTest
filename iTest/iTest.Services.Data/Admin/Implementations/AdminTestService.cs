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

namespace iTest.Services.Data.Admin.Implementations
{
    public class AdminTestService : IAdminTestService
    {
        private readonly IMappingProvider mapper;
        private readonly IRepository<Test> tests;
        private readonly IRepository<Question> questions;
        private readonly IRepository<Category> categories;
        private readonly ISaver saver;

        public AdminTestService(IMappingProvider mapper, IRepository<Test> tests, IRepository<Question> questions, IRepository<Category> categories, ISaver saver)
        {
            this.mapper = mapper ?? throw new ArgumentNullException();
            this.tests = tests ?? throw new ArgumentNullException();
            this.questions = questions ?? throw new ArgumentNullException();
            this.saver = saver ?? throw new ArgumentNullException();
            this.categories = categories ?? throw new ArgumentNullException();
        }

        public IEnumerable<TestDTO> AllByAuthor(string authorId)
        {
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
