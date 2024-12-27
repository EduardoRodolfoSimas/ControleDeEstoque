using ControleDeEstoque.Model;

namespace ControleDeEstoque.Services;

public interface ICategoriaService
{
    Task<List<Categoria>> GetCategorias();
    Task<Categoria> AddCategoria(Categoria categoria);
    Task<Categoria> UpdateCategoria(Categoria categoria);
    Task<Categoria> DeleteCategoria(int id);
    
}