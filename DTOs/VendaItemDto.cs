namespace ControleDeEstoque.DTOs.VendaItemDto;

public class VendaItemDto 
{ 
        public Guid Id { get; set; }
        
        public Guid VendaId { get; set; }
        public Guid ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Subtotal { get; set; }
}
