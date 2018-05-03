﻿using iTest.Data.Models;
using iTest.Data.Repository;
using iTest.Data.Repository.UnitsOfWork;
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
        private readonly ISaver saver;

        public UserTestService(IMappingProvider mapper, IRepository<Test> tests, ISaver saver)
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
                throw new ArgumentException("No tests created yet! Please create one first!");
            }

            return this.mapper.ProjectTo<TestDTO>(tests);
        }

        public async Task<IEnumerable<TestDTO>> AllByCategoryAsync(Category category)
        {
            var tests = await this.tests
                                        .All
                                        .Where(x => x.Category.Name == category.Name)
                                        .ToListAsync();

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
    }
}
