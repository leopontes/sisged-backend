using System;
using System.Collections.Generic;
using NHibernate;

namespace SisGed_Backend.Repository
{
    public abstract class AbstractPersistent<T>: ICrudOperation<T>
    {
        private readonly ISession _session;

        public AbstractPersistent(){}

        public AbstractPersistent(ISession session)
        {
            //_session = session;
            _session = NHibernateHelper.OpenSession();
        }

        public IEnumerable<T> FindAll()
        {
            return _session.Query<T>();
        }

        public T GetById(int id)
        {
            return (T)_session.Get(GetModelClass(), id);
        }

        public void Save(T item)
        {
            using var transaction = _session.BeginTransaction();
            _session.SaveOrUpdate(item);
            transaction.Commit();
        }

        public void Delete(T item)
        {
            using var transaction = _session.BeginTransaction();
            _session.Delete(item);
            transaction.Commit();
        }

        protected abstract Type GetModelClass();
    }
}
