using GoToMo.Api.CQRS;
using GoToMo.Domain.Movies;

namespace GoToMo.Api.Application.Commands.Movies
{
	public record AddProductionStreamingServiceCommand(int ProductionId, int StreamingServiceId) :ICommand;

}
