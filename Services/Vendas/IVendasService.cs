using ControleDeEstoque.DTOs.VendaDto;

namespace ControleDeEstoque.Services.Vendas;

public interface IVendasService
{
    Task<List<VendaDto>> ListarVendas();
    Task<VendaDto> AdicionarVenda(VendaDto vendaDto);
    Task<VendaDto> AtualizarVenda(VendaDto vendaDto);
    Task<VendaDto?> DeletarVenda(Guid id);
    Task<Dictionary<DateTime, List<VendaDto>>> ObterVendasAgrupadasPorDia();
}