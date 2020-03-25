using System;
using System.Collections.Generic;
using SisGed_Backend.Exception;
using SisGed_Backend.Models;
using SisGed_Backend.Repository;

namespace SisGed_Backend.Business
{
    public class TurmaBusiness: ITurmaBusiness
    {
        private readonly ICrudOperation<Turma> turmaRepository;

        private readonly ICrudOperation<Escola> escolaRepository;

        public TurmaBusiness(ICrudOperation<Turma> turmaRepository, ICrudOperation<Escola> escolaRepository)
        {
            this.turmaRepository = turmaRepository;
            this.escolaRepository = escolaRepository;
        }

        public Turma BuscarPor(int id)
        {
            return this.turmaRepository.GetById(id);
        }

        public void CadastrarTurma(Turma turma)
        {
            Escola escola = this.escolaRepository.GetById(turma.Escola.Id);
            turma.Escola = escola ?? throw new BusinessException("A escola nao foi encontrada.");
            this.turmaRepository.Save(turma);
        }

        public void Editar(int id, Turma turma)
        {
            Turma turmaDB = this.turmaRepository.GetById(id);
            Escola escola = this.escolaRepository.GetById(turma.Escola.Id);

            if (turmaDB == null)
                throw new BusinessException("Turma nao encontrada.");

            turmaDB.Codigo = turma.Codigo;
            turmaDB.Ano = turma.Ano;
            turmaDB.TipoEnsino = turma.TipoEnsino;
            turmaDB.Escola = escola ?? throw new BusinessException("Escola nao encontrada.");
            this.turmaRepository.Save(turmaDB);
        }

        public void Excluir(int id)
        {
            Turma turma = this.turmaRepository.GetById(id);

            if (turma == null)
                throw new BusinessException("Turma nao encontrada.");

            this.turmaRepository.Delete(turma);
        }

        public IEnumerable<Turma> Listar()
        {
            return this.turmaRepository.FindAll();
        }
    }
}
