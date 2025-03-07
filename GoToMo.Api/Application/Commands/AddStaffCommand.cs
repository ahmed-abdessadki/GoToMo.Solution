using GoToMo.Api.CQRS;
using GoToMo.Domain.Movies;

namespace GoToMo.Api.Application.Commands
{
	public record AddStaffCommand(string Name, StaffType StaffType) : ICommand;			
	
}
