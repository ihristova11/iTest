using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace iTest.Data.Repository.Contracts
{
    public interface IGenericRepository<TEntity> 
        where TEntity : class, IIdentifiable<int>
    {
        IEnumerable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);
    }
}