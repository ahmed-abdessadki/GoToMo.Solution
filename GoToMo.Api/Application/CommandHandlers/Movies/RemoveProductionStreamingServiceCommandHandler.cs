using GoToMo.Api.Application.Commands.Movies;
using GoToMo.Api.CQRS;
using GoToMo.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GoToMo.Api.Application.CommandHandlers.Movies
{
	public class RemoveProductionStreamingServiceCommandHandler : ICommandHandlerAsync<RemoveProductionStreamingServiceCommand>
	{
		GoToMoUnitOfWork _goToMoUnitOfWork;
		public RemoveProductionStreamingServiceCommandHandler(GoToMoUnitOfWork goToMoUnitOfWork)
		{
			_goToMoUnitOfWork = goToMoUnitOfWork;
		}
		public async Task HandleAsync(RemoveProductionStreamingServiceCommand command)
		{
			var production = await _goToMoUnitOfWork.Productions.AsQueryable().Include(p => p.StreamingServices).FirstOrDefaultAsync(p => p.Id == command.ProductionId);
			if (production is null)
			{
				throw new Exception("Production not found");
			}
			var streamingService = production.StreamingServices.FirstOrDefault(ps => ps.Id == command.StreamingServiceId);
			
			if (streamingService is null)
			{
				throw new Exception("Streamingservice not found");
			}

			production.StreamingServices.Remove(streamingService);
			
			await _goToMoUnitOfWork.SaveChangesAsync();
		}
	}
}
