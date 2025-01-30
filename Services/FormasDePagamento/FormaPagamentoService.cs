using ControleDeEstoque.DTOs.FormaDePagamentoDto;

namespace ControleDeEstoque.Services.FormaDePagamentoService
{
    public class FormaDePagamentoService : IFormaDePagamentoService.IFormaDePagamentoService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "http://localhost:5012/pagamento";

        public FormaDePagamentoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FormaDePagamentoDto>> ListarFormasDePagamento()
        {
            return await _httpClient.GetFromJsonAsync<List<FormaDePagamentoDto>>(ApiUrl) ?? new List<FormaDePagamentoDto>();
        }

        public async Task<FormaDePagamentoDto> AdicionarFormaPagamento(FormaDePagamentoDto formaDePagamentoDto)
        {
            var response = await _httpClient.PostAsJsonAsync(ApiUrl, formaDePagamentoDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<FormaDePagamentoDto>();
        }

        public async Task<FormaDePagamentoDto> AtualizarFormaPagamento(FormaDePagamentoDto formaDePagamentoDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/{formaDePagamentoDto.Id}", formaDePagamentoDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<FormaDePagamentoDto>();
        }

        public async Task<FormaDePagamentoDto?> DeletarFormaPagamento(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{ApiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<FormaDePagamentoDto>();
            }
            return null;
        }
    }
}