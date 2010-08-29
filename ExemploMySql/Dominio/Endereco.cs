namespace ExemploMySql
{
    public class Endereco
    {
        protected Endereco(){}

        public Endereco(string logradouro, int numero, string bairro, UF uf, string pais)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            UF = uf;
            Pais = pais;
        }

        public string Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string Bairro { get; private set; }
        public UF UF { get; private set; }
        public string Pais { get; private set; }
    }
}
