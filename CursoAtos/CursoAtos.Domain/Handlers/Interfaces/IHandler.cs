using CursoAtos.Domain.Commands.Interfaces;

namespace CursoAtos.Domain.Handlers.Interfaces;

public interface IHandler<T> where T : ICommands
{
    ICommandsResult Handle(T command);
}