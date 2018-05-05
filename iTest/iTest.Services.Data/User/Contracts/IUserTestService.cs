using iTest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTest.Services.Data.User.Contracts
{
    public interface IUserTestService
    {
        IEnumerable<TestDTO> All();

        IEnumerable<TestDTO> AllByCategory(string category);

        Task<TestDTO> FindByNameAsync(string name);

        Task<TestDTO> FindByIdAsync(int id);
    }
}
