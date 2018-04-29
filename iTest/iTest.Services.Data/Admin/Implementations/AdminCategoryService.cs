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

        public async Task<IEnumerable<Category>> AllDomainAsync()
            => await this.categories
                                  .All
                                  .ToListAsync();

        public async Task<IEnumerable<CategoryDTO>> AllAsync()
        {
            var categories = await this.categories
                                  .All
                                  .ToListAsync();

            if (!categories.Any())
            {
                throw new ArgumentException($"No categories created yet! Please create one first!");
            }

            return this.mapper.ProjectTo<CategoryDTO>(categories);
        }

        public async Task<CategoryDTO> FindByNameAsync(string name)
        {
            var category = await this.categories
                                  .All
                                  .FirstOrDefaultAsync(x => x.Name == name);

            if (category == null)
            {
                throw new ArgumentException($"Category with name:{name} couldn't be found!");
            }

            return this.mapper.MapTo<CategoryDTO>(category);
        }

        public async Task CreateAsync(CategoryDTO dto)
        {
            var category = this.mapper.MapTo<Category>(dto);

            this.categories.Add(category);
            await this.saver.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategoryDTO dto)
        {
            var category = await this.categories.All.SingleAsync(x => x.Id == dto.Id);

            if (category == null)
            {
                throw new ArgumentException($"Category with name:{dto.Name} was not found!");
            }

            category.Name = dto.Name;
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
            var category = await this.categories.All.SingleAsync(x => x.Id == id);

            if (category == null)
            {
                throw new ArgumentException($"Category with id:{id} was not found!");
            }

            this.categories.Delete(category);
            await this.saver.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await this.categories.All.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await this.categories.All.AnyAsync(x => x.Name == name);
        }
    }
}
