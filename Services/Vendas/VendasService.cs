using ControleDeEstoque.DTOs.VendaDto;
using ControleDeEstoque.Services.Vendas;

namespace ControleDeEstoque.Services.VendasService;

public class VendasService : IVendasService
{
    private readonly HttpClient _httpClient;
    private const string ApiUrl = "https://xn--produoapicontroledeestoque-htbwcagua2g5c2hw-vtd3p.brazilsouth-01.azurewebsites.net/venda";

    public VendasService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<VendaDto>> ListarVendas()
    {
        return await _httpClient.GetFromJsonAsync<List<VendaDto>>(ApiUrl) ?? new List<VendaDto>();
    }

    public async Task<VendaDto> AdicionarVenda(VendaDto vendaDto)
    {
        var response = await _httpClient.PostAsJsonAsync(ApiUrl, vendaDto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<VendaDto>();
    }

    public async Task<VendaDto> AtualizarVenda(VendaDto vendaDto)
    {
        var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/{vendaDto.Id}", vendaDto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<VendaDto>();
    }

    public async Task<VendaDto?> DeletarVenda(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"{ApiUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<VendaDto>();
        }
        return null;
    }
}