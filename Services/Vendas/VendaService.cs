using ControleDeEstoque.Model;
using ControleDeEstoque.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Services.Vendas;

public class VendaService : IVendasService
{
    private readonly DataBaseContext _context;

    public VendaService(DataBaseContext context)
    {
        _context = context;
    }
    
    public async Task<List<Venda>> RegistrarVenda(Venda venda)
    {
        var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Sku == venda.ProdutoSku);
        produto.QuantidadeProduto -= venda.QuantidadeVendida;
        _context.Produtos.Update(produto);
        _context.Vendas.Add(venda);
        await _context.SaveChangesAsync();
        return await ObterVendas();
    }

    public async Task<List<Venda>> ObterVendas()
    { 
        return await _context.Vendas.ToListAsync();
    }
    
    public async Task<List<Venda>> ExcluirVenda()
    {
        var venda = await _context.Vendas.FindAsync(1);
        if (venda != null)
        {
            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();
        }
        return await ObterVendas();
    }
    
    public async Task<Dictionary<DateTime, List<Venda>>> ObterVendasAgrupadasPorDia()
    {
        return await _context.Vendas
            .GroupBy(v => v.DataVenda.Date)
            .ToDictionaryAsync(g => g.Key, g => g.ToList());
    }
}