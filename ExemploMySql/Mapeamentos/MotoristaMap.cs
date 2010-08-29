using FluentNHibernate.Mapping;

namespace ExemploMySql
{
    public class MotoristaMap : ClassMap<Motorista>
    {
        public MotoristaMap()
        {
            Table("motoristas");

            Id(x => x.Id).GeneratedBy.Increment();

            Map(x => x.Nome);
            Map(x => x.CRC);
            Component(x => x.Endereco).ColumnPrefix("Endereco_");
            HasMany(x => x.Carros).Cascade.All();
        }
    }
}