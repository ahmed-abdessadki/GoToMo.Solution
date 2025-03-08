using GoToMo.Api.Application.Commands.Movies;
using GoToMo.Api.CQRS;
using GoToMo.Data.EF;
using GoToMo.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GoToMo.Api.Application.CommandHandlers.Movies
{
	public class DeleteRatingCommandHandler : ICommandHandlerAsync<DeleteRatingCommand>
	{
		GoToMoUnitOfWork _goToMoUnitOfWork;
		public DeleteRatingCommandHandler(GoToMoUnitOfWork goToMoUnitOfWork)
		{
			_goToMoUnitOfWork = goToMoUnitOfWork;
		}
		public async Task HandleAsync(DeleteRatingCommand command)
		{
			var production = _goToMoUnitOfWork.Productions.AsQueryable(withTracking: true).Include(x => x.Ratings).ThenInclude(x => x.User).FirstOrDefault(r => r.Id == command.ProductionId);

			if (production is null)
			{
				throw new Exception("Production not found");
			}			
			
			var rating = production.Ratings.Where(r => r.Id == command.Id).SingleOrDefault();

			if (rating is null)
			{
				throw new Exception("Rating not found");
			}
			
			production.Ratings.Remove(rating);

			await _goToMoUnitOfWork.SaveChangesAsync();
		}
	}
	
}
