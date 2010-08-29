using System.IO;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace ExemploMySql.Testes
{
    [TestFixture]
    public class CriacaoBancoDeDados
    {
        [Test]
        public void CriarSchema()
        {
            Configuration configuration = SessionFactory.Configuration();
            
            var schemaExport = new SchemaExport(configuration);
            using (TextWriter stringWriter = new StreamWriter("C:\\exemploNH.sql"))
            {
                schemaExport.SetDelimiter(";");
                schemaExport.Execute(true, false, false, null, stringWriter);
            }

            // Depois de criar as tabelas no MySQL, altere o Storage Engine delas para
            // InnoDB, assim vc tem suporte a transações (MyISAM, q é o padrão, não suporta).
            // Vc pode fazer isso por comandos sql: 'ALTER TABLE motoristas ENGINE=InnoDB;'
        }
    }
}