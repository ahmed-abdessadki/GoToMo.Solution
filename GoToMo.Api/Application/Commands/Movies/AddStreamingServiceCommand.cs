using GoToMo.Api.CQRS;

namespace GoToMo.Api.Application.Commands.Movies
{
	public record AddStreamingServiceCommand(string Name, string Url) : ICommand;

}
