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
    public class AdminCategoryService : IAdminCategoryService
    {
        private readonly IMappingProvider mapper;
        private readonly IRepository<Category> categories;
        private readonly ISaver saver;

        public AdminCategoryService(IMappingProvider mapper, IRepository<Category> categories, ISaver saver)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.categories = categories ?? throw new ArgumentNullException(nameof(categories));
            this.saver = saver ?? throw new ArgumentNullException(nameof(saver));
        }
        public async Task<IEnumerable<CategoryDTO>> AllAsync()
        {
            var categories = await this.categories
                                  .All
                                  .ToListAsync();

            if (!categories.Any())
            {
                throw new ArgumentException($"Categories couldn't be found!");
            }

            return this.mapper.ProjectTo<CategoryDTO>(categories);
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await this.categories.All.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await this.categories.All.AnyAsync(x => x.Name == name);
        }

        // TODO map all props with automapper
        public async Task CreateAsync(string name)
        {
            var dto = new Category
            {
                Name = name,
            };

            var category = this.mapper.MapTo<Category>(dto);

            this.categories.Add(category);
            await this.saver.SaveChangesAsync();
        }

        // TODO map all props with automapper
        public async Task EditAsync(int id, string name)
        {
            var category = await this.categories.All.SingleAsync(x => x.Id == id);

            if (category == null)
            {
                throw new ArgumentException($"Category with id:{id} was not found!");
            }

            category.Name = name;

            this.categories.Update(category);
            await this.saver.SaveChangesAsync();
        }


        public async Task PublishAsync(CategoryDTO dto)
        {
            var model = this.mapper.MapTo<Category>(dto);
            this.categories.Add(model);
            await this.saver.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var test = await this.categories.All.SingleAsync(x => x.Id == id);

            if (test == null)
            {
                throw new ArgumentException($"Category with id:{id} was not found!");
            }

            this.categories.Delete(test);
            await this.saver.SaveChangesAsync();
        }
    }
}
