using iTest.Data.Models.Implementations;
using iTest.Data.Repository.Contracts;
using iTest.DTO;
using iTest.Infrastructure.Providers;
using iTest.Services.Admin.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTest.Services.Admin.Implementations
{
    public class AdminTestService : IAdminTestService
    {
        private readonly IMappingProvider mapper;
        private readonly IRepository<Test> tests;
        private readonly ISaver saver;

        public AdminTestService(IMappingProvider mapper, IRepository<Test> tests, ISaver saver)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.tests = tests ?? throw new ArgumentNullException(nameof(tests));
            this.saver = saver ?? throw new ArgumentNullException(nameof(saver));
        }

        public Task<IEnumerable<TestDTO>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(int id, string name)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<TestDTO> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TestDTO> GetByTestId(int id)
        {
            throw new NotImplementedException();
        }

        public Task PublishAsync(TestDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
