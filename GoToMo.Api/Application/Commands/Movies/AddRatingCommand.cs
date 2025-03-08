using GoToMo.Api.CQRS;

namespace GoToMo.Api.Application.Commands.Movies
{
	public record AddRatingCommand(int ProductionId, double Rating, string? Source, int? UserId) : ICommand;

}
