using iTest.Data.Models.Implementations;
using iTest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTest.Services.Data.Admin.Contracts
{
    public interface IAdminCategoryService
    {
        Task<IEnumerable<CategoryDTO>> AllAsync();

        Task<IEnumerable<Category>> AllDomainAsync();

        Task<CategoryDTO> FindByNameAsync(string name);

        Task CreateAsync(CategoryDTO dto);

        Task UpdateAsync(string name, CategoryDTO dto);

        Task PublishAsync(CategoryDTO dto);

        Task DeleteAsync(int id);

        Task<bool> ExistsByIdAsync(int id);

        Task<bool> ExistsByNameAsync(string name);
    }
}
