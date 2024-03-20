using CursoAtos.Domain.Commands.Interfaces;
using CursoAtos.Domain.Commands.Noticia;
using CursoAtos.Domain.Commands.Results;
using CursoAtos.Domain.Entities;
using CursoAtos.Domain.Handlers.Interfaces;
using CursoAtos.Domain.Repositories;

namespace CursoAtos.Domain.Handlers;

public class NoticiaHandler :
    IHandler<NoticiaInserirCommand>,
    IHandler<NoticiaAlterarCommand>,
    IHandler<NoticiaExcluirCommand>
{
    private readonly INoticiaRepository _repository;

    #region | Construtores |

    public NoticiaHandler(INoticiaRepository repository)
    {
        _repository = repository;
    }

    #endregion

    #region | Inserir |

    public ICommandsResult Handle(NoticiaInserirCommand command)
    {
        //Fail Fast Validation - Validacao de Erros Rapida
        command.Validar();
        if (command.DeuErro)
        {
            return new CommandsResults(false, "Dados da Notícia estão incorretos.", command.Notificacoes);
        }

        //criando o objeto que vai inserir no banco de dados
        var noticia = new Noticia
        {
            Titulo = command.Titulo,
            Texto = command.Texto,
            UltimaAtualizacao = DateTime.Now
        };

        //inserir efetivamente no banco de dados
        _repository.Inserir(noticia);

        return new CommandsResults(true, "Notícia cadastrada com sucesso!", noticia);
    }

    #endregion

    #region | Alterar |

    public ICommandsResult Handle(NoticiaAlterarCommand command)
    {
        command.Validar();
        if (command.DeuErro)
        {
            return new CommandsResults(false, "Dados da Notícia estão incorretos.", command.Notificacoes);
        }

        //buscar a noticia pelo ID, para fazer o update
        var noticia = _repository.GetById(command.Id);

        if (noticia == null)
        {
            return new CommandsResults(false, "Notícia informada não encontrada.", command.Notificacoes);
        }

        //atualizar os dados da noticia
        noticia.Titulo = command.Titulo;
        noticia.Texto = command.Texto;
        noticia.UltimaAtualizacao = DateTime.Now;

        _repository.Alterar(noticia);

        return new CommandsResults(true, "Notícia alterada com sucesso!", noticia);
    }

    #endregion

    #region | Excluir |

    public ICommandsResult Handle(NoticiaExcluirCommand command)
    {
        command.Validar();
        if (command.DeuErro)
        {
            return new CommandsResults(false, "Dados da Notícia estão incorretos.", command.Notificacoes);
        }

        //buscar a noticia pelo ID, para fazer o update
        var noticia = _repository.GetById(command.Id);
        if (noticia == null)
        {
            return new CommandsResults(false, "Notícia informada não encontrada.", command.Notificacoes);
        }

        _repository.Excluir(command.Id);

        return new CommandsResults(true, "Notícia excluida com sucesso!", command.Notificacoes);
    }

    #endregion
}