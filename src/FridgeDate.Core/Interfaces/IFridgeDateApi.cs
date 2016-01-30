using FridgeDate.Core.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeDate.Core.Interfaces
{
    public interface IFridgeDateApi<T, in TKey> where T : class
    {
        [Post("")]
        Task<T> Create([Body] T payload);

        [Get("")]
        Task<List<T>> ReadAll();

        [Get("/{key}")]
        Task<T> ReadOne(TKey key);

        [Put("/{key}")]
        Task Update(TKey key, [Body]T payload);

        [Delete("/{key}")]
        Task Delete(TKey key);
    }
}
