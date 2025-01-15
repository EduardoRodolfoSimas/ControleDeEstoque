using ControleDeEstoque.DTOs.FormaDePagamentoDto;

namespace ControleDeEstoque.Services.IFormaDePagamentoService;

public interface IFormaDePagamentoService
{
    Task<List<FormaDePagamentoDto>> ListarFormasDePagamento();
    Task<FormaDePagamentoDto> AdicionarFormaPagamento(FormaDePagamentoDto formaPagamentoDto);
    Task<FormaDePagamentoDto> AtualizarFormaPagamento(FormaDePagamentoDto formaPagamentoDto);
    Task<FormaDePagamentoDto?> DeletarFormaPagamento(Guid id);
}