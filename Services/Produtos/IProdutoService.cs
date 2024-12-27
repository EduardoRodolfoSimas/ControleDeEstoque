using ControleDeEstoque.Model;

namespace ControleDeEstoque.Services;

public interface IProdutoService
{
    Task<List<Produto>> GetProdutos();
    Task<Produto> AddProduto(Produto produto);
    Task<Produto> UpdateProduto(Produto produto);
    Task<Produto> DeleteProduto(int id);
    Task<bool> SkuExists(string sku);
}
