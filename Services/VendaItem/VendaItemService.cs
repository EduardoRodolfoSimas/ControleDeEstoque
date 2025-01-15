using ControleDeEstoque.DTOs.VendaItemDto;
using ControleDeEstoque.Services.VendaItem;

namespace ControleDeEstoque.Services.VendaItemService;

public class VendaItemService : IVendaItemService
{
    private readonly HttpClient _httpClient;
    private const string ApiUrl = "https://localhost:44345/vendas";

    public VendaItemService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<VendaItemDto>> ListarVendaItens()
    {
        return await _httpClient.GetFromJsonAsync<List<VendaItemDto>>(ApiUrl) ?? new List<VendaItemDto>();
    }

    public async Task<VendaItemDto> AdicionarVendaItem(VendaItemDto vendaItemDto)
    {
        var response = await _httpClient.PostAsJsonAsync(ApiUrl, vendaItemDto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<VendaItemDto>();
    }

    public async Task<VendaItemDto> AtualizarVendaItem(VendaItemDto vendaItemDto)
    {
        var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/{vendaItemDto.Id}", vendaItemDto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<VendaItemDto>();
    }

    public async Task<VendaItemDto?> DeletarVendaItem(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"{ApiUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<VendaItemDto>();
        }
        return null;
    }
}