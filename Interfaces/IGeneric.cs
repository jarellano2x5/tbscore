using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace tbscore.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        Task<T> GetId(int id);
        Task<IEnumerable<T>> GetAll(int ide);
        Task<int> Create(T entity);
        Task<int> Update(T entity);
        Task<bool> Delete(int id);
    }
}