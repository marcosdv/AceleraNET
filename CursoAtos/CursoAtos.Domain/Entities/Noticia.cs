namespace CursoAtos.Domain.Entities;

public class Noticia
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Texto { get; set; }
    public DateTime UltimaAtualizacao { get; set; }
}