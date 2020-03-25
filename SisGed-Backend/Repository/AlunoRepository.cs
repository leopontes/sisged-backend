using System;
using System.Collections.Generic;
using NHibernate;
using SisGed_Backend.Models;

namespace SisGed_Backend.Repository
{
    public class AlunoRepository: IAlunoRepository
    {
        private readonly ISession _session;

        public AlunoRepository(ISession session)
        {
            _session = session;
        }

        public void Delete(Aluno item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Aluno> FindAll()
        {
            throw new NotImplementedException();
        }

        public Aluno GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Aluno item)
        {
            using var transaction = _session.BeginTransaction();
            _session.SaveOrUpdate(item);
            transaction.Commit();
        }
    }
}
