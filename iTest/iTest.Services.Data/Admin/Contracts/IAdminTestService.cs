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

        Task PublishAsync(TestDTO dto);

        Task CreateAsync(string name, DateTime requestedTime, DateTime executionTime, string status, CategoryDTO category, string authorId, User author, List<Question> questions, List<Result> results);

        Task EditAsync(int id, string name, DateTime requestedTime, DateTime executionTime, string status, CategoryDTO category, string authorId, User author, List<Question> questions, List<Result> results);

        Task DeleteAsync(int id);

        Task<bool> ExistsByIdAsync(int id);

        Task<bool> ExistsByNameAsync(string name);
    }
}
