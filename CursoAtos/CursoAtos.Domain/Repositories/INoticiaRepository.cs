using CursoAtos.Domain.Entities;

namespace CursoAtos.Domain.Repositories;

public interface INoticiaRepository
{
    void Inserir(Noticia noticia);
    void Alterar(Noticia noticia);
    void Excluir(int id);

    IEnumerable<Noticia> Get();
    Noticia? GetById(int id);
    IEnumerable<Noticia> GetUltimoMes();
}