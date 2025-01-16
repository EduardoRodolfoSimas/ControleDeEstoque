using ControleDeEstoque.DTOs.ProdutoDto;

namespace ControleDeEstoque.Services.IProdutoService;

public interface IProdutoService
{
    Task<List<ProdutoDto>> ListarProdutos();
    Task<ProdutoDto> ListarProdutoPorId(Guid id);
    Task<ProdutoDto> AdicionarProduto(ProdutoDto produto);
    Task<ProdutoDto> AtualizarProduto(ProdutoDto produto);
    Task<ProdutoDto> DeletarProduto(Guid id);
}

