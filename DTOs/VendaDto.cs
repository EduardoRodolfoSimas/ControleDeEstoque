

namespace ControleDeEstoque.DTOs.VendaDto;
    public class VendaDto
    {
        public Guid Id { get; set; }
        public DateTime DataVenda { get; set; }
        
        public Guid MetodoPagamentoId { get; set; }
        
        public string MetodoPagamentoTipo { get; set; }
        
        public decimal ValorTotal { get; set; }
        
        public List<VendaItemDto.VendaItemDto> Itens { get; set; }
    }

