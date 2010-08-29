using System.Collections.Generic;

namespace ExemploMySql
{
    public class Motorista
    {
        public Motorista()
        {
            Carros = new List<Carro>();
        }

        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string CRC { get; set; }
        public virtual Endereco Endereco { get; set; }

        public virtual IList<Carro> Carros { get; private set; }

        public virtual void AdicionarCarro(Carro carro)
        {
            carro.Motorista = this;
            Carros.Add(carro);
        }
    }
}