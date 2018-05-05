using iTest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTest.Services.Data.User.Contracts
{
    public interface IUserCategoryService
    {
        IEnumerable<CategoryDTO> All();

        Task<CategoryDTO> FindByIdAsync(int id);

        Task<bool> ExistsByNameAsync(string name);
    }
}
