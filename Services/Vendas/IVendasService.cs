using ControleDeEstoque.Model;

namespace ControleDeEstoque.Services.Vendas;

public interface IVendasService
{
    Task<List<Venda>> RegistrarVenda(Venda venda);
    
    Task<List<Venda>> ObterVendas();
    
    Task<List<Venda>> ExcluirVenda();

}