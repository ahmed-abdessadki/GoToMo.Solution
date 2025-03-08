using GoToMo.Api.CQRS;

namespace GoToMo.Api.Application.Commands.Movies
{
	public record DeleteRatingCommand(int Id, int ProductionId) : ICommand;

}
