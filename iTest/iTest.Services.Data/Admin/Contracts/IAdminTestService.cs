using iTest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTest.Services.Data.Admin.Contracts
{
    public interface IAdminTestService
    {
        IEnumerable<TestDTO> AllByAuthor(string authorId);

        IEnumerable<TestDTO> All();

        Task<TestDTO> FindByIdAsync(int id);

        void Create(TestDTO dto);

        void PublishExistingTest(int id);

        Task UpdateAsync(TestDTO dto);

        Task DeleteAsync(int id);

        Task<bool> ExistsByIdAsync(int id);

        Task<bool> ExistsByNameAsync(string name);
    }
}
