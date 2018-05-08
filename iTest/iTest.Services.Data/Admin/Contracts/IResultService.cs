using System.Collections.Generic;
using iTest.DTO;

namespace iTest.Services.Data.Admin.Contracts
{
    public interface IResultService
    {
        IEnumerable<TestDTO> GetTestsByAuthor(string id);

        IEnumerable<UserTestDTO> GetUserResults();
    }
}
