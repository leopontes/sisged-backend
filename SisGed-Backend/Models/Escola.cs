using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SisGed_Backend.Models
{
    public class Escola
    {
        private int _id;

        public virtual int Id { get { return _id; } set { _id = value; } }

        public virtual string Nome { get; set; }

        public virtual string Diretor { get; set; }

        public virtual string Contato { get; set; }

        public virtual string Local { get; set; }

        [JsonIgnore]
        public virtual IList<Turma> Turmas { get; set; }

        public Escola() {}
    }
}
