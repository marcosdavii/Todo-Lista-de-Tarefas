using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}