namespace ControleDeEstoque.DTOs.ProdutoDto;

public class ProdutoDto
{
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sku { get; set; }
        public decimal ValorUnitario { get; set; }
        public string CategoriaNome { get; set; }
        public string TamanhoNome { get; set; }
        public int Quantidade { get; set; }
        public Guid TamanhoId { get; set; }
        public Guid CategoriaId { get; set; }
}