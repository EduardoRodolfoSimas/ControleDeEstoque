namespace ControleDeEstoque.DTOs.FormaDePagamentoDto
{
    public class FormaDePagamentoDto
    {
        public Guid Id { get; set; } 
        public string Tipo { get; set; } = string.Empty; 
        public string? Descricao { get; set; } 
    }
}