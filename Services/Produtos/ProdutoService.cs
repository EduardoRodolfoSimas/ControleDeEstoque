using ControleDeEstoque.DTOs.ProdutoDto;

namespace ControleDeEstoque.Services.ProdutoService;

public class ProdutoService : IProdutoService.IProdutoService
{
    private readonly HttpClient _httpClient;
    private const string ApiUrl = "https://xn--produoapicontroledeestoque-htbwcagua2g5c2hw-vtd3p.brazilsouth-01.azurewebsites.net/produto";

    public ProdutoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProdutoDto>> ListarProdutos()
    {
        return await _httpClient.GetFromJsonAsync<List<ProdutoDto>>(ApiUrl) ?? new List<ProdutoDto>();
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