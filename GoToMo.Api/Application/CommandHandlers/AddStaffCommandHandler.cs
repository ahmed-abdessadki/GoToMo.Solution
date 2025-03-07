using GoToMo.Api.Application.Commands;
using GoToMo.Api.CQRS;
using GoToMo.Data.EF;
using GoToMo.Domain.Movies;

namespace GoToMo.Api.Application.CommandHandlers
{
	public class AddStaffCommandHandler : ICommandHandlerAsync<AddStaffCommand, Staff>
	{
		GoToMoContext _goToMoUnitOfWork;

		public AddStaffCommandHandler(GoToMoContext goToMoUnitOfWork)
		{
			_goToMoUnitOfWork = goToMoUnitOfWork;
		}
		
		public async Task<Staff> HandleAsync(AddStaffCommand command)
		{
			var newStaff = new Staff(command.Name, command.StaffType);
			_goToMoUnitOfWork.Staff.Add(newStaff);
			await _goToMoUnitOfWork.SaveChangesAsync();
			return newStaff;
		}
	}
}
