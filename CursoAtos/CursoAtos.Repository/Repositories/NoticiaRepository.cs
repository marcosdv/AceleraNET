using CursoAtos.Domain.Entities;
using CursoAtos.Domain.Queries;
using CursoAtos.Domain.Repositories;
using CursoAtos.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CursoAtos.Repository.Repositories;

[ExcludeFromCodeCoverage]
public class NoticiaRepository : INoticiaRepository
{
    private readonly DataContext _dataContext;

    #region Construtor

    public NoticiaRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    #endregion

    #region Metodos 

    public void Inserir(Noticia noticia)
    {
        _dataContext.Noticias.Add(noticia);
        _dataContext.SaveChanges();
    }

    public void Alterar(Noticia noticia)
    {
        _dataContext.Entry(noticia).State = EntityState.Modified;
        _dataContext.SaveChanges();
    }

    public void Excluir(int id)
    {
        var noticia = GetById(id);
        if (noticia != null)
        {
            _dataContext.Remove(noticia);
            _dataContext.SaveChanges();
        }
    }

    public IEnumerable<Noticia> Get()
    {
        return _dataContext.Noticias
            .AsNoTracking()
            .OrderBy(x => x.Titulo)
            .OrderByDescending(x => x.UltimaAtualizacao);
    }

    public Noticia? GetById(int id)
    {
        return _dataContext.Noticias
            .Where(NoticiaQueries.GetById(id)) //.Where(x => x.Id == id)
            .FirstOrDefault();
    }

    public IEnumerable<Noticia> GetUltimoMes()
    {
        return _dataContext.Noticias
            .AsNoTracking()
            .Where(NoticiaQueries.GetUltimoMes()) //.Where(x => x.UltimaAtualizacao >= DateTime.Now.AddMonths(-1))
            .OrderByDescending(x => x.UltimaAtualizacao);
    }

    #endregion
}