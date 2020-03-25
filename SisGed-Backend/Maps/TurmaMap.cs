using System;
using FluentNHibernate.Mapping;
using SisGed_Backend.Models;

namespace SisGed_Backend.Maps
{
    public class TurmaMap: ClassMap<Turma>
    {
        public TurmaMap()
        {
            Id(x => x.Id)
                .GeneratedBy.Identity()
                .UnsavedValue(0)
                .Access.CamelCaseField(Prefix.Underscore);

            Map(x => x.Codigo)
                .Not.Nullable()
                .Length(20);

            Map(x => x.TipoEnsino)
                .CustomType<TipoEnsinoEnum>()
                .Not.Nullable();

            Map(x => x.Ano)
                .Not.Nullable();

            CheckConstraint("tipoEnsino in (1,2,3)");
          
            References(x => x.Escola).Column("escola");

            HasMany(x => x.Alunos).Inverse().Cascade.All().KeyColumn("turma");

            Table("sisged.turma");
        }
    }
}
