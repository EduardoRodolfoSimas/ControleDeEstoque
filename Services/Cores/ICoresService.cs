using ControleDeEstoque.Model;

namespace ControleDeEstoque.Services.Cores;

public interface ICoresService
{
    Task<List<Cor>> GetCors();
    Task<Cor> GetCor(int id);
    Task<Cor> AddCor(Cor cor);
    Task<Cor> UpdateCor(Cor cor);
    Task<Cor> DeleteCor(int id);
}