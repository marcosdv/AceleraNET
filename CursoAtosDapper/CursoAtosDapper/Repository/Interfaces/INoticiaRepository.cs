using CursoAtosDapper.Models;

namespace CursoAtosDapper.Repository.Interfaces;

public interface INoticiaRepository
{
    void Inserir(Noticia noticia);
    void Alterar(Noticia noticia);
    void Excluir(int id);

    Task<IEnumerable<Noticia>> Get();
    IEnumerable<Noticia> GetUltimoMes();
    Noticia? GetById(int id);
}