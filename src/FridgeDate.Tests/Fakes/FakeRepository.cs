using FridgeDate.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using FridgeDate.Data.Models;

namespace FridgeDate.Tests.Fakes
{
    public class FakeRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly Dictionary<string, TEntity> Collection;
        public FakeRepository()
        {
            Collection = new Dictionary<string, TEntity>();
        }
        public TEntity Delete(TEntity entityToDelete)
        {
            if (Collection.ContainsValue(entityToDelete))
                return DeleteById(Collection.First(e => e.Value == entityToDelete).Key);
            return null;
        }

        public TEntity DeleteById(object id)
        {
            string key = id.ToString();
            if (Collection.ContainsKey(key))
            {
                var entityToDelete = Collection[key];
                Collection.Remove(key);
                return entityToDelete;
            }

            return null;
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return await Task.Run<IEnumerable<TEntity>>(() =>
            {
                if (filter != null)
                    return Collection.Values.AsQueryable().Where(filter);
                return Collection.Values;
            });
        }

        public async Task<TEntity> GetByID(object id)
        {
            return await Task.Run(() =>
            {
                string key = id.ToString();
                if (Collection.ContainsKey(key))
                    return Collection[key];
                return null;
            });
        }

        public TEntity Insert(TEntity entity)
        {
            var guid = Guid.NewGuid().ToString();
            dynamic e = entity;
            e.Id = guid;
            Collection.Add(guid, e);
            return e;
        }

        public TEntity Update(TEntity entityToUpdate)
        {
            dynamic e = entityToUpdate;
            Collection.Remove(e.Id);
            Collection.Add(e.Id, entityToUpdate);
            return entityToUpdate;
        }

        public void Clear()
        {
            Collection.Clear();
        }
    }
}
