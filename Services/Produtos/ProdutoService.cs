using ControleDeEstoque.DTOs.ProdutoDto;

namespace ControleDeEstoque.Services.ProdutoService;

public class ProdutoService : IProdutoService.IProdutoService
{
    private readonly HttpClient _httpClient;
    private const string ApiUrl = "http://localhost:5012/produto";

    public ProdutoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProdutoDto>> ListarProdutos()
    {
        return await _httpClient.GetFromJsonAsync<List<ProdutoDto>>(ApiUrl) ?? new List<ProdutoDto>();
    }
    
    public async Task<ProdutoDto?> ListarProdutoPorId(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<ProdutoDto>($"{ApiUrl}/{id}");
    }

    public async Task<ProdutoDto> AdicionarProduto(ProdutoDto produto)
    {
        var response = await _httpClient.PostAsJsonAsync(ApiUrl, produto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ProdutoDto>();
    }

    public async Task<ProdutoDto> AtualizarProduto(ProdutoDto produto)
    {
        var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/{produto.Id}", produto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ProdutoDto>();
    }

    public async Task<ProdutoDto?> DeletarProduto(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"{ApiUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ProdutoDto>();
        }
        return null;
    }
}