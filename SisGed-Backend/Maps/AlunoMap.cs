using System;
using FluentNHibernate.Mapping;
using SisGed_Backend.Models;

namespace SisGed_Backend.Maps
{
    public class AlunoMap: ClassMap<Aluno>
    {
        public AlunoMap()
        {
            Id(x => x.Id)
                .GeneratedBy.Identity()
                .UnsavedValue(0)
                .Access.CamelCaseField(Prefix.Underscore);

            Map(x => x.Nome)
                .Not.Nullable()
                .Length(100);

            Map(x => x.Contato)
                .Not.Nullable()
                .Length(50);

            Map(x => x.Responsavel)
                .Not.Nullable()
                .Length(100);

            References(x => x.Turma)
                .Not.Nullable()
                .Column("turma");

            Table("sisged.aluno");
        }
    }
}
