using ControleDeEstoque.DTOs.TamanhoDto;
using ControleDeEstoque.Services.ITamanhos;

namespace ControleDeEstoque.Services.TamanhoService;

public class TamanhoService : ITamanhoService
{
    private readonly HttpClient _httpClient;
    private const string ApiUrl = "https://xn--produoapicontroledeestoque-htbwcagua2g5c2hw-vtd3p.brazilsouth-01.azurewebsites.net/tamanho";

    public TamanhoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<TamanhoDto>> ListarTamanhos()
    {
        return await _httpClient.GetFromJsonAsync<List<TamanhoDto>>(ApiUrl) ?? new List<TamanhoDto>();
    }

    public async Task<TamanhoDto> AdicionarTamanho(TamanhoDto tamanho)
    {
        var response = await _httpClient.PostAsJsonAsync(ApiUrl, tamanho);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TamanhoDto>();
    }

    public async Task<TamanhoDto> AtualizarTamanho(TamanhoDto tamanho)
    {
        var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/{tamanho.Id}", tamanho);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TamanhoDto>();
    }

    public async Task<TamanhoDto?> DeletarTamanho(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"{ApiUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<TamanhoDto>();
        }
        return null;
    }
}