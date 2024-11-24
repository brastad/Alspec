using Alspec.DataAccess.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
namespace Alspec.DataAccess.Data.Repository
{

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        internal DbSet<T> dbSet;
        public Repository (DbContext context)
        {
            Context = context;
            this.dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public T Get(int Id)
        {
            return dbSet.Find(Id);
        }


        public IEnumerable<T> GetAll(Func<IQueryable<T>, IQueryable<T>> includeMembers)
        {
            DbSet<T> set = Context.Set<T>();

            IQueryable<T> result;
            result = includeMembers(set);

            return result.AsEnumerable();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);

            }
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }


            }                 
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);

            }
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }


            }
            return query.ToList();
        }

        public void Remove(string Id)
        {
            T entityToRemove = dbSet.Find(Id);
            Remove(entityToRemove);


        }
        public void Remove(T entity)
        {
            dbSet.Remove(entity);

        }

     
    }
}
