using CursoAtos.Domain.Commands.Noticia;
using CursoAtos.Domain.Commands.Results;
using CursoAtos.Domain.Handlers;
using CursoAtos.Domain.Repositories;
using CursoAtos.Tests.Repositories;

namespace CursoAtos.Tests.Domain.Handlers;

[TestClass]
public class NoticiaHandlerTests
{
    private readonly INoticiaRepository _repository;
    private readonly NoticiaHandler _handler;

    public NoticiaHandlerTests()
    {
        _repository = new NoticiaRepositoryMock();
        _handler = new NoticiaHandler(_repository);
    }

    #region | Inserir Tests |

    [TestMethod]
    public void DadoUmComandoInserirValidoDeveRetornarSucessoTrue()
    {
        var command = new NoticiaInserirCommand("Titulo", "Texto");

        var result = (CommandsResults)_handler.Handle(command);

        Assert.IsTrue(result.Sucesso);
    }

    [TestMethod]
    public void DadoUmComandoInserirInvalidoDeveRetornarSucessoFalse()
    {
        var command = new NoticiaInserirCommand("", "Texto");

        var result = (CommandsResults)_handler.Handle(command);

        Assert.IsFalse(result.Sucesso);
    }

    #endregion

    #region | Alterar Tests |

    [TestMethod]
    public void DadoUmComandoAlterarValidoDeveRetornarSucessoTrue()
    {
        var command = new NoticiaAlterarCommand(1, "Titulo", "Texto");

        var result = (CommandsResults)_handler.Handle(command);

        Assert.IsTrue(result.Sucesso);
    }

    [DataTestMethod]
    [DataRow(0)]
    [DataRow(10)]
    public void DadoUmComandoAlterarInvalidoDeveRetornarSucessoFalse(int id)
    {
        var command = new NoticiaAlterarCommand(id, "Titulo", "Texto");

        var result = (CommandsResults)_handler.Handle(command);

        Assert.IsFalse(result.Sucesso);
    }

    #endregion

    #region | Excluir Tests |

    [TestMethod]
    public void DadoUmComandoExcluirValidoDeveRetornarSucessoTrue()
    {
        var command = new NoticiaExcluirCommand(1);

        var result = (CommandsResults)_handler.Handle(command);

        Assert.IsTrue(result.Sucesso);
    }

    [DataTestMethod]
    [DataRow(0)]
    [DataRow(10)]
    public void DadoUmComandoExcluirInvalidoDeveRetornarSucessoFalse(int id)
    {
        var command = new NoticiaExcluirCommand(id);

        var result = (CommandsResults)_handler.Handle(command);

        Assert.IsFalse(result.Sucesso);
    }

    #endregion
}