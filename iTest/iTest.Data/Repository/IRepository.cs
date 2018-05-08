using iTest.Data.Models.Abstract;
using System.Linq;

namespace iTest.Data.Repository
{
    public interface IUserTestService<T> where T : class, IDeletable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllAndDeleted { get; }

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
