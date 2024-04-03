using CursoAtos.Domain.Commands.Noticia;

namespace CursoAtos.Tests.Domain.Commands.Noticia;

[TestClass]
public class NoticiaInserirCommandTests
{
    [TestMethod]
    public void DadoUmComandoInserirInvalidoDeveRetornarDeuErro()
    {
        var command = new NoticiaInserirCommand("", "");

        command.Validar();

        Assert.IsTrue(command.DeuErro);
        Assert.IsFalse(command.DeuCerto);
    }

    [TestMethod]
    public void DadoUmComandoInserirValidoDeveRetornarDeuCerto()
    {
        var command = new NoticiaInserirCommand("Titulo Valido", "");

        command.Validar();

        Assert.IsTrue(command.DeuCerto);
        Assert.IsFalse(command.DeuErro);
    }

    [DataTestMethod]
    [DataRow("Titulo", true)]
    [DataRow("", false)]
    public void DadoUmComandoInserirDeveRetornarValorEsperado(string titulo, bool deuCertoEsperado)
    {
        var command = new NoticiaInserirCommand(titulo, "");

        command.Validar();

        Assert.AreEqual(deuCertoEsperado, command.DeuCerto);
    }
}