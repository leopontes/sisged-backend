using System;
using FluentNHibernate.Mapping;
using SisGed_Backend.Models;

namespace SisGed_Backend.Maps
{
    public class EscolaMap: ClassMap<Escola>
    {
        public EscolaMap()
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

            Map(x => x.Diretor)
                .Not.Nullable()
                .Length(100);

            Map(x => x.Local)
                .Not.Nullable()
                .Length(200);

            HasMany(x => x.Turmas).Inverse().Cascade.All().KeyColumn("escola");
            
            Table("sisged.escola");
        }
    }
}
