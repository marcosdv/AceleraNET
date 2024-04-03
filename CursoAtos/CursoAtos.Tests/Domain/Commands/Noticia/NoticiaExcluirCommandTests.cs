using CursoAtos.Domain.Commands.Noticia;

namespace CursoAtos.Tests.Domain.Commands.Noticia;

[TestClass]
public class NoticiaExcluirCommandTests
{
    [TestMethod]
    public void DadoUmComandoAlterarValidoDeveRetornarDeuCerto()
    {
        var command = new NoticiaExcluirCommand(1);
        
        command.Validar();

        Assert.IsTrue(command.DeuCerto);
        Assert.IsFalse(command.DeuErro);
        Assert.AreEqual(0, command.Notificacoes.Count);
    }

    [TestMethod]
    public void DadoUmComandoAlterarInvalidoDeveRetornarDeuErro()
    {
        var command = new NoticiaExcluirCommand(0);

        command.Validar();

        Assert.IsTrue(command.DeuErro);
        Assert.IsFalse(command.DeuCerto);
        Assert.AreEqual(1, command.Notificacoes.Count);
    }
}