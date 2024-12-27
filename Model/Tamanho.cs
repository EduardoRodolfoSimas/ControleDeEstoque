namespace ControleDeEstoque.Model;

public class Tamanho
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataInsercao { get; set; } = DateTime.Now; 
}