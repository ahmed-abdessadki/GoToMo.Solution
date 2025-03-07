using GoToMo.Api.CQRS;
using GoToMo.Domain.Movies;

namespace GoToMo.Api.Application.Commands.Movies
{
	public record AddProductionCommand(string Title, ProductionType ProductionType, string? Url, string? Plot, int? ReleaseYear, int? LengthInMinutes, Genre PrimaryGenre, Genre SecondaryGenre, int SequenceIndex,  int? Season):ICommand;

}
