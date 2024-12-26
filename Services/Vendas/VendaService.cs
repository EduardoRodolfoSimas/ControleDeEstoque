using ControleDeEstoque.Model;
using ControleDeEstoque.Data;
using Microsoft.EntityFrameworkCore;
using ControleDeEstoque.Services.Vendas;
using ControleDeEstoque.Services.Produtos;

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
        _context.Vendas.Add(venda);
        await _context.SaveChangesAsync();
        
        var produto = await _context.Produtos.FindAsync(venda.ProdutoId);
        if (produto != null)
        {
            produto.QuantidadeProduto -= venda.QuantidadeVendida;
            await _context.SaveChangesAsync(); 
        }
        return await _context.Vendas.ToListAsync();
    }

    public async Task<List<Venda>> ObterVendas()
    { 
        return await _context.Vendas.ToListAsync();;
    }
}