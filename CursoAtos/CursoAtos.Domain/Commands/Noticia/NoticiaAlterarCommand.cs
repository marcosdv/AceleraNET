using CursoAtos.Domain.Commands.Interfaces;
using CursoAtos.Domain.Validations;

namespace CursoAtos.Domain.Commands.Noticia;

public class NoticiaAlterarCommand : Notificavel, ICommands
{
    #region | Propriedades |

    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Texto { get; set; }

    #endregion

    #region | Construtores |

    public NoticiaAlterarCommand(int id, string titulo, string texto)
    {
        Id = id;
        Titulo = titulo;
        Texto = texto;
    }

    #endregion

    #region | Métodos |

    public void Validar()
    {
        if (Id <= 0)
        {
            AddNotificacao("O Código da Notícia é obrigatório!");
        }

        if (string.IsNullOrEmpty(Titulo))
        {
            AddNotificacao("O campo Título é obrigatório!");
        }
    }

    #endregion
}