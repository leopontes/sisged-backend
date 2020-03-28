using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using SisGed_Backend.Maps;
using SisGed_Backend.Models;

namespace SisGed_Backend.Repository
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            //string connectionStr = "postgresql://postgres:sucesso@2020@hostname:5432/postgres";
            var connectionStr = "Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=sucesso@2020;";
            var connectionStrHeroku = System.Environment.GetEnvironmentVariable("DATABASE_URL");

            ISessionFactory sessionFactory = Fluently
             .Configure()
             .Database(
                PostgreSQLConfiguration.Standard.ConnectionString(connectionStrHeroku)
                .Dialect<PostgreSQL82Dialect>().ShowSql()
             )
             .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
             .ExposeConfiguration(BuildSchema)
             .BuildSessionFactory();

            /*
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(PostgreSQLConfiguration.Standard
                .ConnectionString(connectionStr)
                .ShowSql()
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Aluno>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(false, false))
                .BuildSessionFactory();**/

            return sessionFactory.OpenSession();
        }

        public NHibernateHelper()
        {
            
        }

        private static void BuildSchema(Configuration configuration)
        {
            var dbSchemaExport = new SchemaExport(configuration);
            dbSchemaExport.Create(false, false);

        }
    }
}
