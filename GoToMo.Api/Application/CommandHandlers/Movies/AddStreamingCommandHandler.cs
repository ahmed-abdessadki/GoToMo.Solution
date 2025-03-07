using GoToMo.Api.Application.Commands.Movies;
using GoToMo.Api.CQRS;
using GoToMo.Data.EF;
using GoToMo.Domain.Movies;

namespace GoToMo.Api.Application.CommandHandlers.Movies
{
	public class AddStreamingCommandHandler : ICommandHandlerAsync<AddStreamingServiceCommand, StreamingService>
	{
		GoToMoContext _goToMoUnitOfWork;
		public AddStreamingCommandHandler(GoToMoContext goToMoUnitOfWork)
		{
			_goToMoUnitOfWork = goToMoUnitOfWork;
		}
		public async Task<StreamingService> HandleAsync(AddStreamingServiceCommand command)
		{
			var newStreamingService = new StreamingService(command.Name, command.Url);
			_goToMoUnitOfWork.StreamingServices.Add(newStreamingService);
			await _goToMoUnitOfWork.SaveChangesAsync();
			return newStreamingService;
		}
	}
	
}
