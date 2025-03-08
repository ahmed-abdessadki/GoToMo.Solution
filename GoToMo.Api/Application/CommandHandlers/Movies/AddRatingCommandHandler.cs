using GoToMo.Api.Application.Commands.Movies;
using GoToMo.Api.CQRS;
using GoToMo.Data.Repositories;
using GoToMo.Domain.Movies;
using Microsoft.EntityFrameworkCore;

namespace GoToMo.Api.Application.CommandHandlers.Movies
{
	public class AddRatingCommandHandler : ICommandHandlerAsync<AddRatingCommand, Rating>
	{
		GoToMoUnitOfWork _goToMoUnitOfWork;
		public AddRatingCommandHandler(GoToMoUnitOfWork goToMoUnitOfWork)
		{
			_goToMoUnitOfWork = goToMoUnitOfWork;
		}

		public async Task<Rating> HandleAsync(AddRatingCommand command)
		{
			var production = _goToMoUnitOfWork.Productions.AsQueryable(withTracking:true).Include(x => x.Ratings).ThenInclude(x => x.User).FirstOrDefault(r => r.Id == command.ProductionId);


			if (production is null)
			{
				throw new Exception("Production not found");
			}

			Rating targetRating = null;

			if (command.UserId.HasValue)
			{
				var user = production.Ratings.Where(r => r.User.Id == command.UserId).Select( x => x.User).SingleOrDefault();
				
				if (user is not null) 
				{
					throw new Exception("Rating source already registered");
				}
				targetRating = new Rating(command.Rating, user);
				
			}
			else if(!string.IsNullOrEmpty(command.Source))
			{
				var rating = production.Ratings.FirstOrDefault(r => r.Source == command.Source);
				
				if (rating is not null)
				{
					throw new Exception("Rating source already registered");
				}

				targetRating = new Rating(command.Rating, command.Source);				
			}
			else
			{
				throw new Exception("Invalid input, either user or source must be set");
			}
			production.Ratings.Add(targetRating);


			await _goToMoUnitOfWork.SaveChangesAsync();

			return targetRating;
		}
	}	
}
