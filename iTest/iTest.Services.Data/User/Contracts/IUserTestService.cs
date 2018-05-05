using iTest.DTO;
using System.Collections.Generic;

namespace iTest.Services.Data.User.Contracts
{
    public interface IUserTestService
    {
        IEnumerable<TestDTO> All();

        IEnumerable<TestDTO> AllByCategory(string category);

        TestDTO FindById(int id);

        UserTestDTO MapStartedTestData(string userId, int testId);
    }
}
