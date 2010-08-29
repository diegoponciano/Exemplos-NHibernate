using System.Collections.Generic;
using FluentNHibernate.Testing;
using NHibernate;
using NUnit.Framework;

namespace ExemploMySql.Testes
{
    [TestFixture]
    public class TestesDosMapeamentos
    {
        private ISessionFactory factory;
        private ISession session;
        readonly Endereco endereco = new Endereco("Rua DotNET", 100, "Jardim Hibernate", UF.SP, "Brasio");
        readonly List<Carro> carros = new List<Carro> { new Carro("Fuscão", "VW"), new Carro("CheVectra", "GM") };

        [SetUp]
        public void SetUp()
        {
            factory = SessionFactory.CreateSessionFactory();
            session = factory.OpenSession();
            session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            // Caso queira ver o resultado no banco, descomente o Commit.
            // Caso faça isso, os testes q usam ExpectedExpection vão falhar (deve ser normal)
            //session.Transaction.Commit(); 
            session.Close();
        }

        [Test]
        public void MapeamentoMotorista()
        {
            new PersistenceSpecification<Motorista>(session, new CustomComparer())
            .CheckProperty(c => c.Id, 0, new EhMaior())
            .CheckProperty(c => c.Nome, "Waldesclécio")
            .CheckProperty(c => c.CRC, "1111-222-SEILÁ")
            .CheckProperty(c => c.Endereco, endereco)
            .VerifyTheMappings();
        }

        [Test]
        public void MapeamentoMotoristaComDoisCarros()
        {
            new PersistenceSpecification<Motorista>(session, new CustomComparer())
            .CheckProperty(c => c.Id, 0, new EhMaior())
            .CheckProperty(c => c.Nome, "Waldesclécio")
            .CheckProperty(c => c.CRC, "1111-222-SEILÁ")
            .CheckProperty(c => c.Endereco, endereco)
            .CheckComponentList(c => c.Carros, carros, (motorista, carro) => motorista.AdicionarCarro(carro))
            .VerifyTheMappings();
        }

        [ExpectedException(typeof(PropertyValueException), ExpectedMessage = "not-null property references a null or transient valueExemploMySql.Carro.Motorista")]
        [Test]
        public void MapeamentoDeCarroSemMotoristaDeveFalhar()
        {
            new PersistenceSpecification<Carro>(session)
                .CheckProperty(c => c.Id, 0, new EhMaior())
                .CheckProperty(c => c.Modelo, "Kombi Branca")
                .CheckProperty(c => c.Fabricante, "VW")
                .VerifyTheMappings();
        }
    }
}
