using System.Collections;

namespace ExemploMySql.Testes
{
    public class CustomComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            if (x is Endereco && y is Endereco)
            {
                return
                    ((Endereco) x).Logradouro == ((Endereco) y).Logradouro &&
                    ((Endereco) x).Numero == ((Endereco) y).Numero &&
                    ((Endereco) x).Numero == ((Endereco) y).Numero &&
                    ((Endereco) x).Bairro == ((Endereco) y).Bairro &&
                    ((Endereco) x).UF == ((Endereco) y).UF &&
                    ((Endereco) x).Pais == ((Endereco) y).Pais;
            }
            if (x is Carro && y is Carro)
            {
                return
                    ((Carro)x).Id == ((Carro)y).Id &&
                    ((Carro)x).Modelo == ((Carro)y).Modelo &&
                    ((Carro)x).Fabricante == ((Carro)y).Fabricante;
            }
            return x.Equals(y);
        }

        public int GetHashCode(object obj)
        {
            return base.GetHashCode();
        }
    }
}