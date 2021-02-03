using RadixTest.Domain.Commands.Contracts;
using System.Threading.Tasks;

namespace RadixTest.Domain.Handlers.Contracts
{
    public interface IHandler<TCommand>
        where TCommand : ICommand
    {
        Task<ICommandResult> Handle(TCommand command);
    }
}
