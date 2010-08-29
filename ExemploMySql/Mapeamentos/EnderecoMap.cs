using FluentNHibernate.Mapping;

namespace ExemploMySql
{
    public class EnderecoMap : ComponentMap<Endereco>
    {
        public EnderecoMap()
        {
            Map(x => x.Logradouro);
            Map(x => x.Numero);
            Map(x => x.Bairro);
            Map(x => x.UF);
            Map(x => x.Pais);
        }
    }
}