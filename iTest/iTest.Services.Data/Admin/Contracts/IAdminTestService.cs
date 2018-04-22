using iTest.Data.Models.Implementations;
using iTest.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTest.Services.Data.Admin.Contracts
{
    public interface IAdminTestService
    {
        Task<IEnumerable<TestDTO>> AllAsync();

        Task<IEnumerable<TestDTO>> FindByIdAsync(int id);

        Task PublishAsync(TestDTO dto);

        Task CreateAsync(string name, DateTime requestedTime, string authorId, CategoryDTO category, List<Question> questions);

        Task EditAsync(int id, string name, DateTime requestedTime, CategoryDTO category, List<Question> questions);

        Task DeleteAsync(int id);

        Task<bool> ExistsByIdAsync(int id);

        Task<bool> ExistsByNameAsync(string name);
    }
}
