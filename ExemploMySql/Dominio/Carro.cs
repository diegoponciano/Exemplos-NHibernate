namespace ExemploMySql
{
    public class Carro
    {
        // É necessário um construtor sem parametros, coisa do NHibernate
        protected Carro(){}

        public Carro(string modelo, string fabricante)
        {
            Id = 0;
            Modelo = modelo;
            Fabricante = fabricante;
        }

        public virtual int Id { get; private set; }
        public virtual string Modelo { get; private set; }
        public virtual string Fabricante { get; private set; }

        public virtual Motorista Motorista { get; set; }
    }
}