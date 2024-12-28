using ControleDeEstoque.Data;
using ControleDeEstoque.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Services.Tamanhos;

public class TamanhoService : ITamanhoService
{
    private readonly DataBaseContext _context;

    public TamanhoService(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<List<Tamanho>> GetTamanhos()
    {
        return await _context.Tamanhos.ToListAsync();
    }

    public async Task<Tamanho> AddTamanho(Tamanho tamanho)
    {
        _context.Tamanhos.Add(tamanho);
        await _context.SaveChangesAsync();
        return tamanho;
    }

public async Task<Tamanho> UpdateTamanho(Tamanho tamanho)
    {
        _context.Entry(tamanho).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return tamanho;
    }

    public async Task<Tamanho> DeleteTamanho(int id)
    {
        var tamanho = await _context.Tamanhos.FindAsync(id);
        if (tamanho == null)
        {
            return null;
        }

        _context.Tamanhos.Remove(tamanho);
        await _context.SaveChangesAsync();
        return tamanho;
    }
    
}