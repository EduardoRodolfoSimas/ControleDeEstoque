namespace ControleDeEstoque.DTOs.PagamentoDto
{
    public class PagamentoDto
    {
        public Guid Id { get; set; } 
        public string Tipo { get; set; } = string.Empty; 
        public string? Descricao { get; set; } 
    }
}