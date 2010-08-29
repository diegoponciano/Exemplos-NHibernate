using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;

namespace ExemploMySql
{
    public class SessionFactory
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return FluentConfiguration().BuildSessionFactory();
        }

        public static Configuration Configuration()
        {
            return FluentConfiguration().BuildConfiguration();
        }

        public static FluentConfiguration FluentConfiguration()
        {
            return Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(c => c
                    .Server("localhost")
                    .Database("exemploNH")
                    .Username("nhibernate")
                    .Password("nhibernate")))
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<MotoristaMap>() 
                    // Adiciona todos os mappings do
                    // mesmo assembly da classe MotoristaMap
                    .Conventions.Add(ForeignKey.EndsWith("Id")));
        }

    }
}