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
        private Dictionary<string, TEntity> _collection;
        public FakeRepository()
        {
            _collection = new Dictionary<string, TEntity>();
        }
        public TEntity Delete(TEntity entityToDelete)
        {
            if (_collection.ContainsValue(entityToDelete))
                return DeleteById(_collection.First(e => e.Value == entityToDelete).Key);
            return null;
        }

        public TEntity DeleteById(object id)
        {
            string key = id.ToString();
            if (_collection.ContainsKey(key))
            {
                var entityToDelete = _collection[key];
                _collection.Remove(key);
                return entityToDelete;
            }

            return null;
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return await Task.Run<IEnumerable<TEntity>>(() =>
            {
                if (filter != null)
                    return _collection.Values.AsQueryable().Where(filter);
                return _collection.Values;
            });
        }

        public async Task<TEntity> GetByID(object id)
        {
            return await Task.Run(() =>
            {
                string key = id.ToString();
                if (_collection.ContainsKey(key))
                    return _collection[key];
                return null;
            });
        }

        public TEntity Insert(TEntity entity)
        {
            var guid = Guid.NewGuid().ToString();
            dynamic e = entity;
            e.Id = guid;
            _collection.Add(guid, e);
            return e;
        }

        public TEntity Update(TEntity entityToUpdate)
        {
            dynamic e = entityToUpdate;
            _collection.Remove(e.Id);
            _collection.Add(e.Id, entityToUpdate);
            return entityToUpdate;
        }

        public void Clear()
        {
            _collection.Clear();
        }
    }
}
