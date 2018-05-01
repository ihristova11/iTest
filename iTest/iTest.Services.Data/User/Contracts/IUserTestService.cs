using iTest.Data.Models;
using iTest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTest.Services.Data.User.Contracts
{
    public interface IUserTestService
    {
        Task<IEnumerable<TestDTO>> AllAsync();

        Task<IEnumerable<TestDTO>> AllByCategoryAsync(Category category);

        Task<TestDTO> FindByNameAsync(string name);
    }
}
