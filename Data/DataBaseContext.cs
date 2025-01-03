using ControleDeEstoque.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Data;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>().ToTable("Produtos");
        modelBuilder.Entity<Categoria>().ToTable("Categoria");
        modelBuilder.Entity<Venda>().ToTable("Vendas");
        modelBuilder.Entity<Tamanho>().ToTable("Tamanhos");
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Venda> Vendas { get; set; }
    public DbSet<Tamanho> Tamanhos { get; set; }
}