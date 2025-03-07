using GoToMo.Api.Application.Commands.Movies;
using GoToMo.Api.CQRS;
using GoToMo.Data.EF;

namespace GoToMo.Api.Application.CommandHandlers.Movies
{
	public class AddProductionStaffCommandHandler : ICommandHandlerAsync<AddProductionStaffCommand>
	{
		GoToMoContext _goToMoUnitOfWork;
		public AddProductionStaffCommandHandler(GoToMoContext goToMoUnitOfWork)
		{
			_goToMoUnitOfWork = goToMoUnitOfWork;
		}
		public async Task HandleAsync(AddProductionStaffCommand command)
		{
			var productionToUpdate = await _goToMoUnitOfWork.Productions.FindAsync(command.ProductionId);

			if(productionToUpdate == null)
			{
				throw new Exception("Production not found");
			}

			if(productionToUpdate.Staff.Any(s => s.Id == command.StaffId))
			{
				throw new Exception("Staff already exists in production");
			}

			var staffToUpdate = await _goToMoUnitOfWork.Staff.FindAsync(command.StaffId);

			if (staffToUpdate == null)
			{
				throw new Exception("Staff not found");
			}

			productionToUpdate.Staff.Add(staffToUpdate);
			
			await _goToMoUnitOfWork.SaveChangesAsync();
		}
	}
}
