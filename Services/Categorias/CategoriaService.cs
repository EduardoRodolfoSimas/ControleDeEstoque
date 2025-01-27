using ControleDeEstoque.DTOs.CategoriaDto;

namespace ControleDeEstoque.Services.CategoriaService;

public class CategoriaService : ICategoriaService.ICategoriaService
{
    private readonly HttpClient _httpClient;
    private const string ApiUrl = "https://localhost:5012/categoria";

    public CategoriaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CategoriaDto>> ListarCategorias()
    {
        return await _httpClient.GetFromJsonAsync<List<CategoriaDto>>(ApiUrl) ?? new List<CategoriaDto>();
    }

    public async Task<CategoriaDto> AdicionarCategoria(CategoriaDto categoria)
    {
        var response = await _httpClient.PostAsJsonAsync(ApiUrl, categoria);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CategoriaDto>();
    }

    public async Task<CategoriaDto> AtualizarCategoria(CategoriaDto categoria)
    {
        var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/{categoria.Id}", categoria);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CategoriaDto>();
    }

    public async Task<CategoriaDto?> DeletarCategoria(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"{ApiUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<CategoriaDto>();
        }
        return null;
    }
}