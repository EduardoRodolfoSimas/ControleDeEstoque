using ControleDeEstoque.DTOs.TamanhoDto;

namespace ControleDeEstoque.Services.ITamanhos;

public interface ITamanhoService
{
    Task<List<TamanhoDto>> ListarTamanhos();
    Task<TamanhoDto> AdicionarTamanho(TamanhoDto tamanhoDto);
    Task<TamanhoDto> AtualizarTamanho(TamanhoDto tamanhoDto);
    Task<TamanhoDto> DeletarTamanho(Guid id);
}