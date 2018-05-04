using iTest.Data.Models;
using iTest.Data.Repository;
using iTest.Infrastructure.Providers;
using iTest.Services.Data.Admin.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using iTest.Data.UnitsOfWork;

namespace iTest.Services.Data.Admin.Implementations
{
    public class AdminCategoryService : IAdminCategoryService
    {
        private readonly IMappingProvider mapper;
        private readonly IRepository<Category> categories;
        private readonly ISaver saver;

        public AdminCategoryService(IMappingProvider mapper, IRepository<Category> categories, ISaver saver)
        {
            this.mapper = mapper;
            this.categories = categories;
            this.saver = saver;
        }
        
        public async Task<IEnumerable<Category>> AllAsync()
            => await this.categories
                                  .All
                                  .ToListAsync();
    }
}
