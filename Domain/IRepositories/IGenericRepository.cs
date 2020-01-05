using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Domain.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        ICollection<T> GetAll();
        T GetById(long id);
        void Add(T obj);
        void Remove(T obj);
        void SaveChanges();
    }
}
