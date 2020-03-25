using System;
using System.Collections.Generic;
using NHibernate;

namespace SisGed_Backend.Repository
{
    public class Persistence<T>: ICrudOperation<T>
    {
        private readonly ISession _session;

        public Persistence(ISession session)
        {
            _session = session;
        }

        public void Delete(T item)
        {
            using var transaction = _session.BeginTransaction();
            _session.Delete(item);
            transaction.Commit();
        }

        public IEnumerable<T> FindAll()
        {
            return _session.Query<T>();
        }

        public T GetById(int id)
        {
            Type t1 = typeof(T);
            //Type[] args = { };
            //Type constructor = t1.MakeGenericType(args);
            //object obj = Activator.CreateInstance(constructor);

            return (T)_session.Get(t1, id);
        }

        public void Save(T item)
        {
            using var transaction = _session.BeginTransaction();
            _session.SaveOrUpdate(item);
            transaction.Commit();
        }
    }
}
