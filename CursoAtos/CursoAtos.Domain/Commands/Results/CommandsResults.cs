using CursoAtos.Domain.Commands.Interfaces;

namespace CursoAtos.Domain.Commands.Results;

public class CommandsResults : ICommandsResult
{
    #region | Propriedades |

    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }
    public object Dados { get; set; }

    #endregion

    #region | Construtores |
    
    public CommandsResults() { }

    public CommandsResults(bool sucesso, string mensagem, object dados)
    {
        Sucesso = sucesso;
        Mensagem = mensagem;
        Dados = dados;
    }

    #endregion
}