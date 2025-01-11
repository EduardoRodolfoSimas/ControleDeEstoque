using ControleDeEstoque.Model;

namespace ControleDeEstoque.Services.ICategoriaService;

public interface ICategoriaService
{
    Task<List<CategoriaDto>> ListarCategorias();
    Task<CategoriaDto> AdicionarCategoria(CategoriaDto categoriaDto);
    Task<CategoriaDto> AtualizarCategoria(CategoriaDto categoriaDto);
    Task<CategoriaDto> DeletarCategoria(Guid id);
    
}