using iTest.Data.Models.Implementations;
using iTest.Data.Repository.Contracts;
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
        private readonly ISaver saver;

        public AdminTestService(IMappingProvider mapper, IRepository<Test> tests, ISaver saver)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.tests = tests ?? throw new ArgumentNullException(nameof(tests));
            this.saver = saver ?? throw new ArgumentNullException(nameof(saver));
        }

        public async Task<IEnumerable<TestDTO>> AllAsync()
        {
            var tests = await this.tests
                                  .All
                                  .ToListAsync();

            if (!tests.Any())
            {
                throw new ArgumentException($"Tests couldn't be found!");
            }

            return this.mapper.ProjectTo<TestDTO>(tests);
        }

        public async Task<IEnumerable<TestDTO>> FindByIdAsync(int id)
        {
            var tests = await this.tests
                                  .All
                                  .Where(x => x.Id == id)
                                  .ToListAsync();
            if (!tests.Any())
            {
                throw new ArgumentException($"Test with id:{id} couldn't be found!");
            }

            return this.mapper.ProjectTo<TestDTO>(tests);
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await this.tests.All.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await this.tests.All.AnyAsync(x => x.Name == name);
        }

        // TODO map all props with automapper
        public async Task CreateAsync(string name, DateTime requestedTime, CategoryDTO category, List<Question> questions)
        {
            var dto = new Test
            {
                Name = name,
                RequestedTime = requestedTime,
                // ExecutionTime = executionTime,
                // Status = (Status)Enum.Parse(typeof(Status), status, true),
                Category = this.mapper.MapTo<Category>(category),
                //AuthorId = authorId,
                // Author = author,
                Questions = questions,
                // Results = results

            };

            var test = this.mapper.MapTo<Test>(dto);

            this.tests.Add(test);
            await this.saver.SaveChangesAsync();
        }

        // TODO map all props with automapper
        public async Task EditAsync(int id, string name, DateTime requestedTime, CategoryDTO category, List<Question> questions)
        {
            var test = await this.tests.All.SingleAsync(x => x.Id == id);

            if (test == null)
            {
                throw new ArgumentException($"Test with id:{id} was not found!");
            }

            test.Name = name;
            test.RequestedTime = requestedTime;
            //test.ExecutionTime = executionTime;
            //test.Status = (Status)Enum.Parse(typeof(Status), status, true);
            test.Category = this.mapper.MapTo<Category>(category);
            //test.AuthorId = authorId;
            //test.Author = author;
            test.Questions = questions;
            //test.Results = results;

            this.tests.Update(test);
            await this.saver.SaveChangesAsync();
        }


        public async Task PublishAsync(TestDTO dto)
        {
            var model = this.mapper.MapTo<Test>(dto);
            this.tests.Add(model);
            await this.saver.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var test = await this.tests.All.SingleAsync(x => x.Id == id);

            if (test == null)
            {
                throw new ArgumentException($"Test with id:{id} was not found!");
            }

            this.tests.Delete(test);
            await this.saver.SaveChangesAsync();
        }
    }
}
