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
        public virtual Categoria? CategoriaNavigation { get; set; }        
        [Precision(18, 2)]
        public decimal PrecoUnitario { get; set; } 
        public int QuantidadeProduto { get; set; } 
        public bool DataExclusao { get; set; } 
        public DateTime DataInsercao { get; set; } = DateTime.Now; 
}