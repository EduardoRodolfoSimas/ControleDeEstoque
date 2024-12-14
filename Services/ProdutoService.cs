using ControleDeEstoque.Data;
using ControleDeEstoque.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Services;

public class ProdutoService : IProdutoService
{
    private readonly DataBaseContext _context;

    public ProdutoService(DataBaseContext context)
    {   
        _context = context;
    }

    public async Task<List<Produto>> GetProdutos()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Produto> GetProduto(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null)
        {
            throw new Exception("Produto não achado");
        }
        return produto;
    }

    public async Task<Produto> AddProduto(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> UpdateProduto(Produto produto)
    {
        _context.Entry(produto).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> DeleteProduto(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto != null)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
        return produto;
    }
    
    public async Task<bool> SkuExists(string sku)
    {
        return await _context.Produtos.AnyAsync(p => p.Sku == sku);
    }
    
}