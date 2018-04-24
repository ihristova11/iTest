using iTest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTest.Services.Data.Admin.Contracts
{
    public interface IAdminCategoryService
    {
        Task<IEnumerable<CategoryDTO>> AllAsync();

        Task<CategoryDTO> FindByNameAsync(string name);

        Task CreateAsync(CategoryDTO dto);

        Task UpdateAsync(CategoryDTO dto);

        Task PublishAsync(CategoryDTO dto);

        Task DeleteAsync(int id);

        Task<bool> ExistsByIdAsync(int id);

        Task<bool> ExistsByNameAsync(string name);
    }
}
