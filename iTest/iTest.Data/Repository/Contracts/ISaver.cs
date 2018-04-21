using System.Threading.Tasks;

namespace iTest.Data.Repository.Contracts
{
    public interface ISaver
    {
        void SaveChanges();

        Task SaveChangesAsync();
    }
}
