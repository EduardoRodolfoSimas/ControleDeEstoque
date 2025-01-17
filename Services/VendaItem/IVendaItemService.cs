using ControleDeEstoque.DTOs.VendaItemDto;

namespace ControleDeEstoque.Services.IVendaItemService;

public interface IVendaItemService
{
    Task<List<VendaItemDto>> ListarVendaItens(Guid vendaId);
    Task<VendaItemDto> AdicionarVendaItem(VendaItemDto vendaItemDto);
    Task<VendaItemDto> AtualizarVendaItem(VendaItemDto vendaItemDto);
    Task<VendaItemDto?> DeletarVendaItem(Guid id);
}