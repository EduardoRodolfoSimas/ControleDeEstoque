using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Model;

public class Venda
{
    public int Id { get; set; }
    public int ProdutoId { get; set; } 
    public Produto Produto { get; set; } 
    public int QuantidadeVendida { get; set; }
    [Precision(18, 2)]
    public decimal PrecoUnitario { get; set; }
    public string FormaPagamento { get; set; }
    public DateTime DataVenda { get; set; }
}