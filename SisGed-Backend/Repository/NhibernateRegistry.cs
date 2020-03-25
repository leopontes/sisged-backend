using System;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Cfg;
using StructureMap;

namespace SisGed_Backend.Repository
{
    public class NhibernateRegistry: Registry
    {
        public NhibernateRegistry()
        {
            For<ISessionFactory>().Singleton().Use(GetSessionFactory());
            For<ISession>().H.Use()
        }

        private Expression<Func<IContext, ISessionFactory>> GetSessionFactory()
        {
            throw new NotImplementedException();
        }
    }
}
