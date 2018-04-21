using iTest.DTO;
using System.Collections.Generic;

namespace iTest.Services.Admin.Contracts
{
    public interface IAdminDashboardService
    {
        IEnumerable<TestDTO> GetByTestId(int id);

        void Publish(TestDTO dto);

        void Delete(int id);

    }
}
