using ControleDeEstoque.Components;
using ControleDeEstoque.Services.ProdutoService;
using ControleDeEstoque.Services.Vendas;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using ControleDeEstoque.Services.CategoriaService;
using ControleDeEstoque.Services.ICategoriaService;
using ControleDeEstoque.Services.IProdutoService;
using ControleDeEstoque.Services.ITamanhos;
using ControleDeEstoque.Services.TamanhoService;
using ControleDeEstoque.Services.VendasService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();   
builder.Services.AddScoped<IVendasService, VendasService>();
builder.Services.AddScoped<ITamanhoService, TamanhoService>();
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseAddress"]);
});

builder.Services.AddBlazorise(options =>
{
    options.Immediate = true;
});
builder.Services.AddBootstrap5Providers();
builder.Services.AddFontAwesomeIcons();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();  

app.Run();