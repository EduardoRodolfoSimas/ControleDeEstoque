using ControleDeEstoque.Components;
using ControleDeEstoque.Data;
using ControleDeEstoque.Services;
using ControleDeEstoque.Services.Produtos;
using ControleDeEstoque.Services.Categorias;
using ControleDeEstoque.Services.Vendas;
using ControleDeEstoque.Services.Tamanhos;
using Microsoft.EntityFrameworkCore;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using ControleDeEstoque.Services.Tamanhos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();   
builder.Services.AddScoped<IVendasService, VendaService>();
builder.Services.AddScoped<ITamanhoService, TamanhoService>();

builder.Services.AddBlazorise(options =>
{
    options.Immediate = true;
});
builder.Services.AddBootstrap5Providers();
builder.Services.AddFontAwesomeIcons();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataBaseContext>();

    context.Database.EnsureCreated();
    
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();  

app.Run();