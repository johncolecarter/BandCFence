using System;
using System.Collections.Generic;
using System.Linq;
using BandCFenceAPI.Core.Models;

namespace BandCFenceAPI.Core.Services
{
    public interface IRepository<T, TKey> where T : class, IEntity<TKey>
    {
        IQueryable<T> Entities { get; }

        T Add(T entity);
        T Get(TKey id);
        IEnumerable<T> GetAll();
        T Update(T entity);
        void Remove(T entity);
    }
}
