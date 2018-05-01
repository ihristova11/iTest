using iTest.Data.Models.Implementations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTest.Services.Data.Admin.Contracts
{
    public interface IAdminCategoryService
    {
        Task<IEnumerable<Category>> AllAsync();
    }
}
