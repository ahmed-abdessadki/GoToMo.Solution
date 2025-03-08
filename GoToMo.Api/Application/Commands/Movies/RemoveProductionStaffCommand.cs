using GoToMo.Api.CQRS;

namespace GoToMo.Api.Application.Commands.Movies
{
	public record RemoveProductionStaffCommand(int ProductionId, int StaffId) : ICommand;

}
