using iTest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTest.Services.Data.User.Contracts
{
    public interface IUserTestService
    {
        Task<IEnumerable<TestDTO>> AllAsync();

        Task<TestDTO> FindByNameAsync(string name);
    }
}
