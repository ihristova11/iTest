namespace iTest.Data.Repository.Contracts
{
    public interface ISaver
    {
        void SaveChanges();

        void SaveChangesAsync();
    }
}
