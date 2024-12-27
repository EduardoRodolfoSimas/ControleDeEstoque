using ControleDeEstoque.Model;

namespace ControleDeEstoque.Services.Tamanhos;

public interface ITamanhoService
{
    Task<List<Tamanho>> GetTamanhos();
    Task<Tamanho> AddTamanho(Tamanho tamanho);
    Task<Tamanho> UpdateTamanho(Tamanho tamanho);
    Task<Tamanho> DeleteTamanho(int id);
}