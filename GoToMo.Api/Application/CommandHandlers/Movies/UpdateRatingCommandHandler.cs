using GoToMo.Api.Application.Commands.Movies;
using GoToMo.Api.CQRS;
using GoToMo.Data.EF;
using GoToMo.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GoToMo.Api.Application.CommandHandlers.Movies
{
	public class UpdateRatingCommandHandler : ICommandHandlerAsync<UpdateRatingCommand>
	{
		GoToMoUnitOfWork _goToMoUnitOfWork;
		public UpdateRatingCommandHandler(GoToMoUnitOfWork goToMoUnitOfWork)
		{
			_goToMoUnitOfWork = goToMoUnitOfWork;
		}
		public async Task HandleAsync(UpdateRatingCommand command)
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
			
			rating.RatingValue = command.Rating;

			await _goToMoUnitOfWork.SaveChangesAsync();
		}
	}
	
}
