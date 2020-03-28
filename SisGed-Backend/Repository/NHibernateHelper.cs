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
            // var connectionStr = "Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=sucesso@2020;";
            // var connectionStrHeroku = System.Environment.GetEnvironmentVariable("DATABASE_URL");
            /*
        postgres://
        
        //usuario
        giadvikqhnkfsi:
        //senha
        1fe72e7dcf7ea2fadcc6c07060c6eb0dbd8fbacaf2afc97facac028a1ed1e461
        //host
        @ec2-34-206-252-187.compute-1.amazonaws.com:
        //porta
        5432
        //banco        
        d80o1da7m1q37u
        */

            Console.WriteLine("::::::::: Variaveis de ambiente ::::::::");
            Console.WriteLine(System.Environment.GetEnvironmentVariable("USR", EnvironmentVariableTarget.Machine));
            Console.WriteLine(System.Environment.GetEnvironmentVariable("PASSWORD", EnvironmentVariableTarget.Machine));
            Console.WriteLine(System.Environment.GetEnvironmentVariable("HOST", EnvironmentVariableTarget.Machine));
            Console.WriteLine(System.Environment.GetEnvironmentVariable("PORT", EnvironmentVariableTarget.Machine));
            Console.WriteLine(System.Environment.GetEnvironmentVariable("DB", EnvironmentVariableTarget.Machine));
            Console.WriteLine("::::::::: Variaveis de ambiente ::::::::");

            ISessionFactory sessionFactory = Fluently
             .Configure()
             .Database(
                PostgreSQLConfiguration.Standard.ConnectionString(conn=>
                    conn
                        .Username(System.Environment.GetEnvironmentVariable("USR", EnvironmentVariableTarget.Machine))
                        .Password(System.Environment.GetEnvironmentVariable("PASSWORD", EnvironmentVariableTarget.Machine))
                        .Host(System.Environment.GetEnvironmentVariable("HOST", EnvironmentVariableTarget.Machine))
                        .Port(Int32.Parse(System.Environment.GetEnvironmentVariable("PORT", EnvironmentVariableTarget.Machine)))
                        .Database(System.Environment.GetEnvironmentVariable("DB", EnvironmentVariableTarget.Machine))
              )
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
