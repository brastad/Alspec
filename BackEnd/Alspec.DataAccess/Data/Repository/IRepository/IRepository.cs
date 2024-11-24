using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Alspec.DataAccess.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T Get(int Id);

        IEnumerable<T> GetAll(Func<IQueryable<T>, IQueryable<T>> includeMembers);

        IEnumerable<T> GetList(
    Expression<Func<T, bool>> filter = null,
    string includeProperties = null
);
        void Add(T entity);
        void Update(T entity);
        void Remove(string Id);

    }
}
