using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Model;

public class Venda
{
    public int Id { get; set; }

    public string ProdutoSku { get; set; }
    public string ProdutoNome { get; set; }
    public int? CategoridaId { get; set; }
    [ForeignKey("CategoridaId")]
    public virtual Categoria Categoria { get; set; }

    public int TamanhoId { get; set; }
    [ForeignKey("TamanhoId")]
    public virtual Tamanho Tamanho { get; set; }
    public int QuantidadeVendida { get; set; }

    [Precision(18, 2)] public decimal PrecoUnitario { get; set; }

    public string FormaPagamento { get; set; }

    public decimal Subtotal => PrecoUnitario * QuantidadeVendida;

    public DateTime DataVenda { get; set; }
    
}
