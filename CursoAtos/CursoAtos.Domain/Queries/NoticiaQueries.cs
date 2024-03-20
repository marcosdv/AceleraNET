using CursoAtos.Domain.Entities;
using System.Linq.Expressions;

namespace CursoAtos.Domain.Queries;

public class NoticiaQueries
{
    public static Expression<Func<Noticia, bool>> GetById(int id)
    {
        //WHERE noticia.NotCodigo == id
        return x => x.Id == id;
    }

    public static Expression<Func<Noticia, bool>> GetUltimoMes()
    {
        return x => x.UltimaAtualizacao >= DateTime.Now.AddMonths(-1);
    }
}