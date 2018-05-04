﻿using iTest.Data.Models;
using iTest.Data.Repository;
using iTest.DTO;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.User.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iTest.Data.UnitsOfWork;

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
            this.mapper = mapper;
            this.categories = categories;
            this.tests = tests;
            this.saver = saver;
        }

        public IEnumerable<CategoryDTO> All()
        {
            var allCategories = this.categories.All;

            return this.mapper.ProjectTo<CategoryDTO>(allCategories);
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
