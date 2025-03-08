using GoToMo.Api.CQRS;

namespace GoToMo.Api.Application.Commands.Movies
{
	public record UpdateRatingCommand(int Id, int ProductionId, double Rating) : ICommand;

}
