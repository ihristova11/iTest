using iTest.Data.Models;
using iTest.Data.Repository;
using iTest.Data.UnitsOfWork;
using iTest.DTO;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.User.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTest.Services.Data.User.Implementations
{
    public class UserTestService : IUserTestService
    {
        private readonly IMappingProvider mapper;
        private readonly IRepository<Test> tests;
        private readonly IRepository<Category> categories;
        private readonly ISaver saver;

        public UserTestService(IMappingProvider mapper, IRepository<Test> tests, IRepository<Category> categories, ISaver saver)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.tests = tests ?? throw new ArgumentNullException(nameof(tests));
            this.categories = categories ?? throw new ArgumentNullException(nameof(categories));
            this.saver = saver ?? throw new ArgumentNullException(nameof(saver));
        }

        public IEnumerable<TestDTO> All()
        {
            var tests = this.tests.All;

            return this.mapper.ProjectTo<TestDTO>(tests);
        }

        public IEnumerable<TestDTO> AllByCategory(string category)
        {
            //Random rnd = new Random();

            var tests = this.tests
                                .All
                                .Where(x => x.Category.Name == category);
            //.OrderBy(x => rnd.Next())
            //.Take(count)
            //.FirstOrDefault();

            return this.mapper.ProjectTo<TestDTO>(tests);
        }

        public async Task<TestDTO> FindByNameAsync(string name)
        {
            var test = await this.tests
                                  .All
                                  .FirstOrDefaultAsync(x => x.Name == name);

            if (test == null)
            {
                throw new ArgumentException($"Test with name:{name} couldn't be found!");
            }

            return this.mapper.MapTo<TestDTO>(test);
        }

        public async Task<TestDTO> FindByIdAsync(int id)
        {
            var test = await this.tests
                                  .All
                                  .FirstOrDefaultAsync(x => x.Id == id);

            if (test == null)
            {
                throw new ArgumentException($"Test with name:{id} couldn't be found!");
            }

            return this.mapper.MapTo<TestDTO>(test);
        }
    }
}
