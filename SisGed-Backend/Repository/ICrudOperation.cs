using System;
using System.Collections.Generic;

namespace SisGed_Backend.Repository
{
    public interface ICrudOperation<T>
    {
        void Save(T item);
        void Delete(T item);
        T GetById(int id);
        IEnumerable<T> FindAll();
    }
}
