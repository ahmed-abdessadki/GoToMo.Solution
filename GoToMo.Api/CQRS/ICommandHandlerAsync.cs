using System.Threading.Tasks;

namespace GoToMo.Api.CQRS
{
    public interface ICommandHandlerAsync<in TCommand, TResponse> where TCommand : class, GoToMo.Api.CQRS.ICommand
    {
        Task<TResponse> HandleAsync(TCommand command);
    }

    public interface ICommandHandlerAsync<in TCommand> where TCommand : class, GoToMo.Api.CQRS.ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
