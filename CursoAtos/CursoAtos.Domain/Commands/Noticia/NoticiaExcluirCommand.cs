using CursoAtos.Domain.Commands.Interfaces;
using CursoAtos.Domain.Validations;

namespace CursoAtos.Domain.Commands.Noticia;

public class NoticiaExcluirCommand : Notificavel, ICommands
{
    #region | Propriedades |

    public int Id { get; set; }

    #endregion

    #region | Construtores |

    public NoticiaExcluirCommand(int id)
    {
        Id = id;
    }

    #endregion

    #region | Métodos |

    public void Validar()
    {
        if (Id <= 0)
        {
            AddNotificacao("O Código da Notícia é obrigatório!");
        }
    }

    #endregion
}