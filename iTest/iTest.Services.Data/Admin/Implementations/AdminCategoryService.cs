using iTest.Data.Models;
using iTest.Data.Repository;
using iTest.DTO;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iTest.Data.UnitsOfWork;

namespace iTest.Services.Data.Admin.Implementations
{
    public class AdminCategoryService : IAdminCategoryService
    {
        private readonly IMappingProvider mapper;
        private readonly IRepository<Category> categories;
        private readonly IRepository<Test> tests;
        private readonly ISaver saver;

        public AdminCategoryService(IMappingProvider mapper, IRepository<Category> categories, IRepository<Test> tests, ISaver saver)
        {
            this.mapper = mapper ?? throw new ArgumentNullException("mapper null");
            this.categories = categories ?? throw new ArgumentNullException("mapper null");
            this.tests = tests ?? throw new ArgumentNullException("mapper null");
            this.saver = saver ?? throw new ArgumentNullException("mapper null");
        }

        public async Task<IEnumerable<Category>> AllAsync()
            => await this.categories
                                  .All
                                  .ToListAsync();

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

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await this.categories.All.AnyAsync(x => x.Name == name);
        }

        public async Task CreateAsync(CategoryDTO dto)
        {
            var category = await this.categories.All.SingleOrDefaultAsync(x => x.Id == dto.Id);

            if (category != null)
            {
                throw new ArgumentException($"{dto.Name} already exits!");
            }

            var model = this.mapper.MapTo<Category>(dto);
            this.categories.Add(model);
            this.saver.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategoryDTO dto)
        {
            var category = await this.categories.All.SingleOrDefaultAsync(x => x.Id == dto.Id);

            if (category == null)
            {
                throw new ArgumentException($"{dto.Name} was not found!");
            }

            // do not map! otherwise a new instance will be created in db
            category.Name = dto.Name;
            category.Tests = dto.Tests;

            this.categories.Update(category);
            this.saver.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await this.categories.All.SingleOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                throw new ArgumentException($"Test with id:{id} was not found!");
            }

            this.categories.Delete(category);

            foreach (var test in category.Tests)
            {
                this.tests.Delete(test);
            }

            this.saver.SaveChangesAsync();
        }
    }
}
