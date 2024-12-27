using ControleDeEstoque.Data;
using ControleDeEstoque.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Services.Categorias;

public class CategoriaService : ICategoriaService
{
    private readonly DataBaseContext _context;

    public CategoriaService(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<Categoria> AddCategoria(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> DeleteCategoria(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);
        if (categoria == null)
        {
            return null;
        }
        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> GetCategoria(int id)
    {
        return await _context.Categorias.FindAsync(id);
    }

    public async Task<List<Categoria>> GetCategorias()
    {
        return await _context.Categorias.ToListAsync();
    }

    public async Task<Categoria> UpdateCategoria(Categoria categoria)
    {
        _context.Entry(categoria).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return categoria;
    }
    
}