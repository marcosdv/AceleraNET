using CursoAtos.Domain.Commands.Interfaces;
using CursoAtos.Domain.Validations;

namespace CursoAtos.Domain.Commands.Noticia;

public class NoticiaInserirCommand : Notificavel, ICommands
{
    #region | Propriedades |

    public string Titulo { get; set; }
    public string Texto { get; set; }

    #endregion

    #region | Construtores |

    public NoticiaInserirCommand(string titulo, string texto)
    {
        Titulo = titulo;
        Texto = texto;
    }

    #endregion

    #region | Métodos |

    public void Validar()
    {
        if (string.IsNullOrEmpty(Titulo))
        {
            AddNotificacao("O campo Título é obrigatório!");
        }
    }

    #endregion
}