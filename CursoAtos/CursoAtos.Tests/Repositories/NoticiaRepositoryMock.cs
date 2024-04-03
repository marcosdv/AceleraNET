using CursoAtos.Domain.Entities;
using CursoAtos.Domain.Queries;
using CursoAtos.Domain.Repositories;

namespace CursoAtos.Tests.Repositories;

public class NoticiaRepositoryMock : INoticiaRepository
{
    private List<Noticia> _noticias;

    public NoticiaRepositoryMock()
    {
        _noticias = new List<Noticia>();
        _noticias.Add(new Noticia { Id = 1, Titulo = "Titulo", Texto = "Texto", UltimaAtualizacao = DateTime.Now.AddMonths(-2) });
        _noticias.Add(new Noticia { Id = 2, Titulo = "Titulo 2", Texto = "", UltimaAtualizacao = DateTime.Now });
    }

    public IEnumerable<Noticia> Get()
    {
        return _noticias;
    }

    public Noticia? GetById(int id)
    {
        return _noticias.AsQueryable().Where(NoticiaQueries.GetById(id)).FirstOrDefault();
    }

    public IEnumerable<Noticia> GetUltimoMes()
    {
        return _noticias.AsQueryable().Where(NoticiaQueries.GetUltimoMes());
    }

    public void Inserir(Noticia noticia) { }

    public void Alterar(Noticia noticia) { }

    public void Excluir(int id) { }
}