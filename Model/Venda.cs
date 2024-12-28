using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Model;

public class Venda
{
    public int Id { get; set; }

    public string ProdutoSku { get; set; }
    public string ProdutoNome { get; set; }
    public int? CategoriaId { get; set; }
    [ForeignKey("CategoriaId")]
    public virtual Categoria Categoria { get; set; }

    public int? TamanhoId { get; set; }
    [ForeignKey("TamanhoId")]
    public virtual Tamanho Tamanho { get; set; }
    public int QuantidadeVendida { get; set; }

    [Precision(18, 2)] public decimal PrecoUnitario { get; set; }

    public string FormaPagamento { get; set; }

    public decimal Subtotal => PrecoUnitario * QuantidadeVendida;
    public  string CategoriaNome => Categoria?.Nome;
    public string TamanhoNome => Tamanho?.Nome;
    public DateTime DataVenda { get; set; }
    
}
