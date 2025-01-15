using ControleDeEstoque.DTOs.VendaDto;
using ControleDeEstoque.Services.Vendas;

namespace ControleDeEstoque.Services.VendasService;

public class VendasService : IVendasService
{
    private readonly HttpClient _httpClient;
    private const string ApiUrl = "https://localhost:44345/vendaitem";

    public VendasService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<VendaDto>> ListarVendas()
    {
        return await _httpClient.GetFromJsonAsync<List<VendaDto>>(ApiUrl) ?? new List<VendaDto>();
    }
    
    public async Task<Dictionary<DateTime, List<VendaDto>>> ObterVendasAgrupadasPorDia()
    {
        var vendas = await ListarVendas();

        return vendas
            .GroupBy(v => v.DataVenda.Date)
            .ToDictionary(g => g.Key, g => g.ToList());
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