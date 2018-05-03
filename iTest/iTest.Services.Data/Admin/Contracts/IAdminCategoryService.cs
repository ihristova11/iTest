using iTest.Data.Models;
using iTest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTest.Services.Data.Admin.Contracts
{
    public interface IAdminCategoryService
    {
        Task<IEnumerable<Category>> AllAsync();

        Task<CategoryDTO> FindByIdAsync(int id);

        Task<bool> ExistsByNameAsync(string name);

        Task CreateAsync(CategoryDTO dto);

        Task UpdateAsync(CategoryDTO dto);

        Task DeleteAsync(int id);
    }
}
