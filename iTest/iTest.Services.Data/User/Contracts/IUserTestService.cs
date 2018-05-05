using iTest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTest.Services.Data.User.Contracts
{
    public interface IUserTestService
    {
        Task<IEnumerable<TestDTO>> AllAsync();

        IEnumerable<TestDTO> GetRandomTest(int count = 1);

        Task<TestDTO> FindByNameAsync(string name);

        Task<TestDTO> FindByNameAsync(int id);
    }
}
