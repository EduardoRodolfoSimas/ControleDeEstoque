using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Model;

public class Produto
{
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sku { get; set; }
        
        public int? CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }
        
        public int? TamanhoId { get; set; }
        [ForeignKey("TamanhoId")]
        public virtual Tamanho Tamanho { get; set; }

        [Precision(18, 2)]
        public decimal PrecoUnitario { get; set; }

        public int QuantidadeProduto { get; set; }

        public bool IsExcluido { get; set; }

        public DateTime DataInsercao { get; set; } = DateTime.Now;
}