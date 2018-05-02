using iTest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTest.Services.Data.Admin.Contracts
{
    public interface IAdminTestService
    {
        Task<IEnumerable<TestDTO>> AllByAuthorAsync(string authorId);

        Task<TestDTO> FindByIdAsync(int id);

        void Create(TestDTO dto);

        Task UpdateAsync(TestDTO dto);

        Task DeleteAsync(int id);

        Task<bool> ExistsByIdAsync(int id);

        Task<bool> ExistsByNameAsync(string name);
    }
}
