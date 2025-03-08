using GoToMo.Api.Application.Commands.Movies;
using GoToMo.Api.CQRS;
using GoToMo.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GoToMo.Api.Application.CommandHandlers.Movies
{
	public class AddProductionStreamingServiceCommandHandler : ICommandHandlerAsync<AddProductionStreamingServiceCommand>
	{
		GoToMoUnitOfWork _goToMoUnitOfWork;
		public AddProductionStreamingServiceCommandHandler(GoToMoUnitOfWork goToMoUnitOfWork)
		{
			_goToMoUnitOfWork = goToMoUnitOfWork;
		}
		public async Task HandleAsync(AddProductionStreamingServiceCommand command)
		{
			var productionToUpdate = await _goToMoUnitOfWork.Productions.AsQueryable(withTracking:true).Include(x => x.StreamingServices).FirstOrDefaultAsync(x => x.Id == command.ProductionId);

			if (productionToUpdate is null)
			{
				throw new Exception("Production not found");
			}

			if(productionToUpdate.StreamingServices.Any(s => s.Id == command.StreamingServiceId))
			{
				throw new Exception("Streamingservice already exists in production");
			}

			var streamingServiceToAdd = await _goToMoUnitOfWork.StreamingServices.GetByIdAsync(command.StreamingServiceId);

			if (streamingServiceToAdd is null)
			{
				throw new Exception("Streamingservice not found");
			}

			productionToUpdate.StreamingServices.Add(streamingServiceToAdd);
			
			await _goToMoUnitOfWork.SaveChangesAsync();
		}
	}
}
