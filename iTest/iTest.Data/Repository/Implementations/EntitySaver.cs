using iTest.Data.Repository.Contracts;

namespace iTest.Data.Repository.Implementations
{
    public class EntitySaver : ISaver
    {
        private readonly iTestDbContext context;

        public EntitySaver(iTestDbContext context) => this.context = context;

        public void SaveChanges() => this.context.SaveChanges();

        public async void SaveChangesAsync() => await this.context.SaveChangesAsync();
    }

}
