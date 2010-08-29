using System.Collections;

namespace ExemploMySql.Testes
{
    public class EhMaior : IEqualityComparer
    {
        bool IEqualityComparer.Equals(object x, object y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            if (x is Motorista && y is Motorista)
            {
                return ((Motorista)y).Id > ((Motorista)x).Id;
            }

            return (int)y > (int)x;
        }

        public int GetHashCode(object obj)
        {
            return base.GetHashCode();
        }
    }
}