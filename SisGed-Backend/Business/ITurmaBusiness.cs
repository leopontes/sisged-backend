using System;
using System.Collections.Generic;
using SisGed_Backend.Models;

namespace SisGed_Backend.Business
{
    public interface ITurmaBusiness
    {
        void CadastrarTurma(Turma turma);
        IEnumerable<Turma> Listar();
        Turma BuscarPor(int id);
        void Editar(int id, Turma turma);
        void Excluir(int id);
    }
}
