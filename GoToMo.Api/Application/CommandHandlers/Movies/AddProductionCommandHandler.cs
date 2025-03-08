using GoToMo.Api.Application.Commands.Movies;
using GoToMo.Api.CQRS;
using GoToMo.Data.Repositories;
using GoToMo.Domain.Movies;

namespace GoToMo.Api.Application.CommandHandlers.Movies
{
	public class AddProductionCommandHandler : ICommandHandlerAsync<AddProductionCommand, Production>
	{
		GoToMoUnitOfWork _goToMoUnitOfWork;
		public AddProductionCommandHandler(GoToMoUnitOfWork goToMoUnitOfWork)
		{
			_goToMoUnitOfWork = goToMoUnitOfWork;
		}
		public async Task<Production> HandleAsync(AddProductionCommand command)
		{
			var newProduction = new Production(command.Title, command.ProductionType)
			{
				ReleaseYear = command.ReleaseYear,
				LengthInMinutes = command.LengthInMinutes,
				Plot = command.Plot??string.Empty,
				Url = command.Url,
				PrimaryGenre = command.PrimaryGenre,
				SecondaryGenre = command.SecondaryGenre,
				Season = command.Season,
				SequenceIndex = command.SequenceIndex
			};


			_goToMoUnitOfWork.Productions.Add(newProduction);
			await _goToMoUnitOfWork.SaveChangesAsync();
			return newProduction;
		}
	}
}
