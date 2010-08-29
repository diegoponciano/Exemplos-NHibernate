using FluentNHibernate.Mapping;

namespace ExemploMySql
{
    public class CarroMap : ClassMap<Carro>
    {
        public CarroMap()
        {
            Table("carros");

            Id(x => x.Id).GeneratedBy.Increment();

            Map(x => x.Modelo);
            Map(x => x.Fabricante);
            References(x => x.Motorista).Not.Nullable();
        }
    }
}