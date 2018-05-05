namespace iTest.Data.UnitsOfWork
{
    public interface ISaver
    {
        void SaveChanges();

        void SaveChangesAsync();
    }
}
