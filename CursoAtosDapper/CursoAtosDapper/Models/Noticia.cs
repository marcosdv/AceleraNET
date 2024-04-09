namespace CursoAtosDapper.Models;

public class Noticia : Entidade
{
    public string Titulo { get; set; }
    public string Texto { get; set; }
    public DateTime UltimaAtualizacao { get; set; }

    public Noticia()
    {
        
    }

    public Noticia(int id, string titulo, string texto, DateTime ultimaAtualizacao)
    {
        Id = id;
        Titulo = titulo;
        Texto = texto;
        UltimaAtualizacao = ultimaAtualizacao;
    }
}