using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using iTest.Data.Models.Contracts;
using iTest.Data.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace iTest.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IIdentifiable<int>, IDeletable
    {
        private readonly iTestDbContext context;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(iTestDbContext context)
        {
            this.context = context;
            this.dbSet = this.Context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(int id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public void Attach(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Unchanged;
        }

        public TEntity GetById(int id)
        {
            return this.DbSet
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TEntity> All
        {
            get
            {
                return this.DbSet
                    .AsNoTracking()
                    .Where(x => !x.IsDeleted)
                    .AsEnumerable();
            }
        }

        public IEnumerable<TEntity> AllAndDeleted => this.DbSet
            .AsNoTracking()
            .AsEnumerable();

        protected iTestDbContext Context => context;

        protected DbSet<TEntity> DbSet => dbSet;

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate) => this.DbSet
            .AsNoTracking()
            .Where(predicate)
            .AsEnumerable();

        public void Insert(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Added;
        }

        public void Update(TEntity entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return this.dbSet
                .Where(predicate)
                .AsEnumerable();
        }

    }
}