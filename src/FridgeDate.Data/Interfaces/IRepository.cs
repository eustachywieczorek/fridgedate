using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FridgeDate.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<TEntity> GetByID(object id);

        TEntity Insert(TEntity entity);

        TEntity DeleteById(object id);

        TEntity Delete(TEntity entityToDelete);

        TEntity Update(TEntity entityToUpdate);
    }
}
