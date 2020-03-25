using System;
namespace SisGed_Backend.Models
{
    public class Aluno
    {
        private int _id;

        public virtual int Id { get { return _id; } set { _id = value; } }

        public virtual string Nome { get; set; }

        public virtual string Responsavel { get; set; }

        public virtual string Contato { get; set; }

        public virtual Turma Turma { get; set; }

        public Aluno(){}

    }
}
