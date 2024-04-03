using CursoAtos.Domain.Entities;
using CursoAtos.Domain.Queries;
using CursoAtos.Tests.Repositories;

namespace CursoAtos.Tests.Domain.Queries;

[TestClass]
public class NoticiaQueriesTests
{
    private IEnumerable<Noticia> listaNoticias;

    public NoticiaQueriesTests()
    {
        var repository = new NoticiaRepositoryMock();
        listaNoticias = repository.Get();
    }

    [TestMethod]
    public void AoRealizarConsultaDoUltimoMesDeveRetornarUmItem()
    {
        var result = listaNoticias.AsQueryable().Where(NoticiaQueries.GetUltimoMes()).ToList();

        Assert.AreEqual(1, result.Count);
    }

    [TestMethod]
    public void AoRealizarConsultaPorIdValidoDeveRetornarUmaNoticia()
    {
        var result = listaNoticias.AsQueryable().Where(NoticiaQueries.GetById(1)).FirstOrDefault();

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Id);
    }

    [TestMethod]
    public void AoRealizarConsultaPorIdInvalidoDeveRetornarNulo()
    {
        var result = listaNoticias.AsQueryable().Where(NoticiaQueries.GetById(10)).FirstOrDefault();

        Assert.IsNull(result);
    }
}