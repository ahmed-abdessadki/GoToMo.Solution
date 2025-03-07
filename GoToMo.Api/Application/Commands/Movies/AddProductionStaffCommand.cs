using GoToMo.Api.CQRS;

namespace GoToMo.Api.Application.Commands.Movies
{
	public record AddProductionStaffCommand(int ProductionId, int StaffId) : ICommand;

}
