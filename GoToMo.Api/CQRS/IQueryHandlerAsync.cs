using System.Threading.Tasks;

namespace GoToMo.Api.CQRS
{
    /// <summary>
    /// Interface for Handling a query against database/persistance.
    /// </summary>
    /// <typeparam name="TQuery">A parameter object that must return TResult by implementing interface IQuery</typeparam>
    /// <typeparam name="TResult">Result that queryhandler returns as an async Task. Usuallly projected DTO objects</typeparam>
    public interface IQueryHandlerAsync<in TQuery, TResult> where TQuery : class, GoToMo.Api.CQRS.IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
