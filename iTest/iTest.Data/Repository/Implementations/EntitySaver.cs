using iTest.Data.Repository.Contracts;
using System.Threading.Tasks;

namespace iTest.Data.Repository.Implementations
{
    public class EntitySaver : ISaver
    {
        private readonly iTestDbContext context;

        public EntitySaver(iTestDbContext context) => this.context = context;

        public void SaveChanges() => this.context.SaveChanges();

        public async Task SaveChangesAsync() => await this.context.SaveChangesAsync();
    }

}
