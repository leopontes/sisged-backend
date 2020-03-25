using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SisGed_Backend.Models
{
    public class Turma
    {
        private int _id;

        public virtual int Id { get { return _id; } set { _id = value; } }

        [Required(ErrorMessage = "O campo código é obrigatório.")]
        [StringLength(20, ErrorMessage = "O campo código precisa ter no máximo 20 caracteres.")]
        public virtual string Codigo { get; set; }

        [Required(ErrorMessage = "O campo tipo de ensino é obrigatório.")]
        [Range(1, 3, ErrorMessage = "O campo tipo ensino precisar ser informado (1 - Ensino fundamental, 2 - Ensino médiom 3 - Ensino superior)")]
        public virtual TipoEnsinoEnum TipoEnsino { get; set; }

        [Required(ErrorMessage = "O campo ano é obrigatório.")]
        public virtual int Ano { get; set; }

        [Required(ErrorMessage = "O campo escola é obrigatório.")]
        public virtual Escola Escola { get; set; }

        public virtual IList<Aluno> Alunos { get; set; }

        public Turma() {}
    }
}
