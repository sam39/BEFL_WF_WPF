using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;

namespace BL
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal DbContextBEFL context;
        internal DbSet<TEntity> dbSet;

        public event RepositoryChangeHandler Changed;
        public delegate void RepositoryChangeHandler(GenericRepository<TEntity> source, EventArgs e);

        public GenericRepository(DbContextBEFL context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        //private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        //{
        //    IQueryable<TEntity> query = dbSet;
        //    return includeProperties
        //        .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        //}


        //public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        //{
        //    return Include(includeProperties).ToList();
        //}


        public virtual IEnumerable<TEntity> GetAll(bool proxy = true)
        {
            context.Configuration.ProxyCreationEnabled = proxy;
            IQueryable<TEntity> query = dbSet;
            return query.ToList();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            if (Changed != null) Changed(this, EventArgs.Empty);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Reload(TEntity entityToUpdate)
        {
            if (entityToUpdate != null)
                context.Entry(entityToUpdate).Reload();
        }
    }
}
