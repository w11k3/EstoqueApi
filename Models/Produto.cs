using System.Text.Json.Serialization;

namespace EstoqueApi.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "tipo")]
    [JsonDerivedType(typeof(ProdutoPerecivel), "perecivel")]
    [JsonDerivedType(typeof(ProdutoEletronico), "eletronico")]
    public class Produto
    {
        public int Id { get; set; }

        private string? _nome;

        public string? Nome
        {
            get { return _nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _nome = "Produto sem nome";
                }
                else
                {
                    _nome = value.Trim();
                }
            }
        }

        private decimal _preco;

        public decimal Preco
        {
            get { return _preco; }
            set
            {
                if (value < 0)
                {
                    _preco = 0;
                }
                else
                {
                    _preco = value;
                }
            }
        }

        private int _quantidade;

        public int Quantidade
        {
            get 
            { 
                return _quantidade; 
            }
            private set 
            { 
                _quantidade = value; 
            }
        }

        public bool AdicionarEstoque(int quantidade)
        {
            if (quantidade <= 0)
            {
                return false;
            }

            Quantidade += quantidade;
            return true;
        }

        public bool RetirarEstoque(int quantidade)
        {
            if (quantidade <= 0 || quantidade > Quantidade)
            {
                return false;
            }

            Quantidade -= quantidade;
            return true;
        }
    }
}
