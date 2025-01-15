namespace ControleDeEstoque.DTOs.ProdutoDto;

public class ProdutoDto
{
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public decimal ValorUnitario { get; set; }
        public string CategoriaNome { get; set; } = string.Empty;
        public string TamanhoNome { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public Guid TamanhoId { get; set; }
        public Guid CategoriaId { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataExclusao { get; set; }
}