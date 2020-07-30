using System;
using System.Collections.Generic;

namespace tbscore.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        T GetId(int id);
        IEnumerable<T> GetAll(int ide);
        int Create(T entity);
        int Update(T entity);
        bool Delete(int id);
    }
}