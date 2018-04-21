using iTest.Data.Models.Implementations;
using iTest.Data.Repository.Contracts;
using iTest.DTO;
using iTest.Infrastructure.Providers;
using iTest.Services.Admin.Contracts;
using System;
using System.Collections.Generic;

namespace iTest.Services.Admin.Implementations
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly IMappingProvider mapper;
        private readonly IRepository<Test> tests;

        public AdminDashboardService(IMappingProvider mapper, IRepository<Test> test)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.tests = test ?? throw new ArgumentNullException(nameof(test));
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TestDTO> GetByTestId(int id)
        {
            throw new NotImplementedException();
        }

        public void Publish(TestDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
