using iTest.Data.Models;
using iTest.Data.Repository;
using iTest.Data.Repository.UnitsOfWork;
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
    public class AdminTestService : IAdminTestService
    {
        private readonly IMappingProvider mapper;
        private readonly IRepository<Test> testsRepo;
        private readonly ISaver saver;

        public AdminTestService(IMappingProvider mapper, IRepository<Test> testsRepo, ISaver saver)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.testsRepo = testsRepo ?? throw new ArgumentNullException(nameof(testsRepo));
            this.saver = saver ?? throw new ArgumentNullException(nameof(saver));
        }

        public async Task<IEnumerable<TestDTO>> AllByAuthorAsync(string authorId)
        {
            var tests = await this.testsRepo
                                  .All
                                  .Include(x => x.Author)
                                  .Where(x => x.AuthorId == authorId)
                                  .ToListAsync();

            return this.mapper.ProjectTo<TestDTO>(tests);
        }

        public async Task<TestDTO> FindByIdAsync(int id)
        {
            var test = await this.testsRepo
                                  .All
                                  .FirstOrDefaultAsync(x => x.Id == id);

            if (test == null)
            {
                throw new ArgumentException($"Test with id:{id} couldn't be found!");
            }

            return this.mapper.MapTo<TestDTO>(test);
        }

        public void Create(TestDTO dto)
        {
            var test = this.mapper.MapTo<Test>(dto);

            this.testsRepo.Add(test);
            this.saver.SaveChangesAsync();
        }

        public async Task UpdateAsync(TestDTO dto)
        {
            var test = await this.testsRepo.All.SingleAsync(x => x.Id == dto.Id);

            if (test == null)
            {
                throw new ArgumentException($"{dto.Name} was not found!");
            }

            this.testsRepo.Update(test);
            this.saver.SaveChangesAsync();
        }

        public void Publish(TestDTO dto)
        {
            var test = this.mapper.MapTo<Test>(dto);
            this.testsRepo.Add(test);
            this.saver.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var test = await this.testsRepo.All.SingleAsync(x => x.Id == id);

            if (test == null)
            {
                throw new ArgumentException($"Test with id:{id} was not found!");
            }

            this.testsRepo.Delete(test);
            this.saver.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await this.testsRepo.All.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await this.testsRepo.All.AnyAsync(x => x.Name == name);
        }
    }
}
