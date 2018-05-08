using iTest.Data.Models.Enums;
using iTest.DTO;
using System.Collections.Generic;

namespace iTest.Services.Data.User.Contracts
{
    public interface IUserTestService
    {
        IEnumerable<TestDTO> All();

        IEnumerable<TestDTO> AllByCategory(string category);

        TestDTO FindById(int id);

        void SaveResult(UserTestDTO dto);

        ResultStatus GetTestResultByUser(string userId, int testId);
    }
}
