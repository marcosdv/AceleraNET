using CursoAtos.Domain.Commands.Noticia;

namespace CursoAtos.Tests.Domain.Commands.Noticia;

[TestClass]
public class NoticiaAlterarCommandTests
{
    [TestMethod]
    public void DadoUmComandoAlterarValidoDeveRetornarDeuCerto()
    {
        var command = new NoticiaAlterarCommand(1, "Titulo Valido", "");
        
        command.Validar();

        Assert.IsTrue(command.DeuCerto);
        Assert.IsFalse(command.DeuErro);
    }

    [DataTestMethod]
    [DataRow(0, "")]
    [DataRow(0, "Titulo")]
    [DataRow(1, "")]
    public void DadoUmComandoAlterarInvalidoDeveRetornarDeuErro(int id, string titulo)
    {
        var command = new NoticiaAlterarCommand(id, titulo, "");

        command.Validar();

        Assert.IsTrue(command.DeuErro);
        Assert.IsFalse(command.DeuCerto);
    }
}