using iTest.Infrastructure.Providers;
using iTest.Services.Admin.Contracts;
using System;

namespace iTest.Services.Admin.Implementations
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly IMappingProvider mapper;

        public AdminDashboardService(IMappingProvider mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
