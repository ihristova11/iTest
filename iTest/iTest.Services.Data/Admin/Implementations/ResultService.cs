using System;
using System.Collections.Generic;
using System.Linq;
using iTest.Data.Models;
using iTest.Data.Repository;
using iTest.Data.UnitsOfWork;
using iTest.DTO;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using Microsoft.EntityFrameworkCore;

namespace iTest.Services.Data.Admin.Implementations
{
    public class ResultService : IResultService
    {
        private readonly ISaver saver;
        private readonly IMappingProvider mapper;
        private readonly IRepository<Test> tests;
        private readonly IRepository<UserTest> userTests;

        public ResultService(ISaver saver, IMappingProvider mapper, IRepository<Test> tests, IRepository<UserTest> userTests)
        {
            this.saver = saver ?? throw new ArgumentNullException("Saver can not be null");
            this.mapper = mapper ?? throw new ArgumentNullException("Mapper can not be null");
            this.tests = tests ?? throw new ArgumentNullException("Tests repo can not be null");
            this.userTests = userTests ?? throw new ArgumentNullException("Tests repo can not be null");

        }

        public IEnumerable<TestDTO> GetTestsByAuthor(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException();
            }

            var authorTests = tests.All.Where(t => t.AuthorId == id).Include(c => c.Category);

            var dto = mapper.ProjectTo<TestDTO>(authorTests);

            return dto;
        }

        public IEnumerable<UserTestDTO> GetUserResults()
        {
            var userResults = userTests.All.Include(t => t.Test).Include(u => u.User);
                //.Where(ur => ur.StartedOn + ur.RequestedTime < DateTime.Now.AddSeconds(5));

            var dto = mapper.ProjectTo<UserTestDTO>(userResults);

            return dto;
        }
    }
}
