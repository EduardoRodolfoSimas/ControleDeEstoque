using ControleDeEstoque.DTOs.VendaItemDto;

namespace ControleDeEstoque.Services.VendaItem;

public interface IVendaItemService
{
    Task<List<VendaItemDto>> ListarVendaItens();
    Task<VendaItemDto> AdicionarVendaItem(VendaItemDto vendaItemDto);
    Task<VendaItemDto> AtualizarVendaItem(VendaItemDto vendaItemDto);
    Task<VendaItemDto?> DeletarVendaItem(Guid id);
}