using System;
using iTest.Data.Models;
using iTest.Data.Repository;
using iTest.Data.UnitsOfWork;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;

namespace iTest.Services.Data.Admin.Implementations
{
    public class ResultService : IResultService
    {
        private readonly ISaver saver;
        private readonly IMappingProvider mapper;
        private readonly IRepository<UserTest> userTests;

        public ResultService(ISaver saver, IMappingProvider mapper, IRepository<UserTest> userTests)
        {
            this.saver = saver ?? throw new ArgumentNullException("Saver can not be null");
            this.mapper = mapper ?? throw new ArgumentNullException("Mapper can not be null"); ;
            this.userTests = userTests ?? throw new ArgumentNullException("Tests repo can not be null");
        }
    }
}
