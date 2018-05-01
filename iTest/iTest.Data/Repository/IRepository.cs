using iTest.Data.Models.Contracts;
using System.Linq;

namespace iTest.Data.Repository
{
    public interface IRepository<T> where T : class, IDeletable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllAndDeleted { get; }

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
