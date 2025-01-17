using ControleDeEstoque.DTOs.VendaDto;
using ControleDeEstoque.DTOs.VendaItemDto;

namespace ControleDeEstoque.Services.IVendasService;

public interface IVendasService
{
    Task<List<VendaDto>> ListarVendas();
    Task<VendaDto> AdicionarVenda(VendaDto vendaDto);
    Task<VendaDto> AtualizarVenda(VendaDto vendaDto);
    Task<VendaDto?> DeletarVenda(Guid id);
    Task<Dictionary<DateTime, List<VendaDto>>> ObterVendasAgrupadasPorDia();
    Task AdicionarItem(VendaItemDto vendaItemDto); // Adicione este método

}