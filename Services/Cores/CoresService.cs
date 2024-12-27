using ControleDeEstoque.Data;
using ControleDeEstoque.Model;
using ControleDeEstoque.Services.Cores;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Services.Cores
{
    public class CoresService : ICoresService
    {
        private readonly DataBaseContext _context;

        public CoresService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Cor> AddCor(Cor cor)
        {
            _context.Cores.Add(cor);
            await _context.SaveChangesAsync();
            return cor;
        }

        public async Task<Cor> DeleteCor(int id)
        {
            var cor = await _context.Cores.FindAsync(id);
            if (cor == null)
            {
                return null;
            }
            _context.Cores.Remove(cor);
            await _context.SaveChangesAsync();
            return cor;
        }

        public async Task<Cor> GetCor(int id)
        {
            return await _context.Cores.FindAsync(id);
        }

        public async Task<List<Cor>> GetCores()
        {
            return await _context.Cores.ToListAsync();
        }

        public async Task<Cor> UpdateCor(Cor cor)
        {
            _context.Entry(cor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cor;
        }

    }
}

