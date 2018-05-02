namespace iTest.Data.Repository.UnitsOfWork
{
    public interface ISaver
    {
        void SaveChanges();

        void SaveChangesAsync();
    }
}
