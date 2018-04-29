using iTest.Data;

namespace ITest.Data.UnitOfWork
{
    public class DataSaver : IDataSaver
    {
        private readonly iTestDbContext context;

        public DataSaver(iTestDbContext context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public async void SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
