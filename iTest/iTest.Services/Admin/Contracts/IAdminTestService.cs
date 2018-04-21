using iTest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTest.Services.Admin.Contracts
{
    public interface IAdminTestService
    {
        IEnumerable<TestDTO> GetByTestId(int id);

        Task<TestDTO> FindByIdAsync(int id);

        Task<IEnumerable<TestDTO>> AllAsync();

        Task PublishAsync(TestDTO dto);

        Task CreateAsync(string name);

        Task EditAsync(int id, string name);

        Task DeleteAsync(int id);

        bool ExistsById(int id);

        bool ExistsByName(string name);

    }
}
