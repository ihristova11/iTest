using iTest.Data.Models;
using iTest.Data.Repository;
using iTest.Data.UnitsOfWork;
using iTest.DTO;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.User.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTest.Services.Data.User.Implementations
{
    public class UserCategoryService : IUserCategoryService
    {
        private readonly IMappingProvider mapper;
        private readonly IRepository<Category> categories;
        private readonly IRepository<Test> tests;
        private readonly ISaver saver;

        public UserCategoryService(IMappingProvider mapper, IRepository<Category> categories, IRepository<Test> tests, ISaver saver)
        {
            this.mapper = mapper ?? throw new ArgumentNullException();
            this.categories = categories ?? throw new ArgumentNullException();
            this.tests = tests ?? throw new ArgumentNullException();
            this.saver = saver ?? throw new ArgumentNullException();
        }

        public IEnumerable<CategoryDTO> All()
        {
            var categories = this.categories.All;

            return this.mapper.ProjectTo<CategoryDTO>(categories);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await this.categories.All.AnyAsync(x => x.Name == name);
        }

        public async Task<CategoryDTO> FindByIdAsync(int id)
        {
            var category = await this.categories
                                            .All
                                            .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                throw new ArgumentException($"Category with id:{id} couldn't be found!");
            }

            return this.mapper.MapTo<CategoryDTO>(category);
        }
    }
}
