namespace EstoqueApi.Models
{
    public class ProdutoPerecivel : Produto
    {
        public DateTime DataValidade { get; set; }
        public bool Vencido => DataValidade.Date < DateTime.Today;
    }
}