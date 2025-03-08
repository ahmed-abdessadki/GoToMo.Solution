using GoToMo.Api.Application.Commands.Movies;
using GoToMo.Api.CQRS;
using GoToMo.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GoToMo.Api.Application.CommandHandlers.Movies
{
	public class AddProductionStaffCommandHandler : ICommandHandlerAsync<AddProductionStaffCommand>
	{
		GoToMoUnitOfWork _goToMoUnitOfWork;
		public AddProductionStaffCommandHandler(GoToMoUnitOfWork goToMoUnitOfWork)
		{
			_goToMoUnitOfWork = goToMoUnitOfWork;
		}
		public async Task HandleAsync(AddProductionStaffCommand command)
		{
			var productionToUpdate = await _goToMoUnitOfWork.Productions.AsQueryable(withTracking:true).Include(x => x.Staff).FirstOrDefaultAsync(x => x.Id == command.ProductionId);

			if (productionToUpdate is null)
			{
				throw new Exception("Production not found");
			}

			if(productionToUpdate.Staff.Any(s => s.Id == command.StaffId))
			{
				throw new Exception("Staff already exists in production");
			}

			var staffToUpdate = await _goToMoUnitOfWork.Staff.GetByIdAsync(command.StaffId);

			if (staffToUpdate is null)
			{
				throw new Exception("Staff not found");
			}

			productionToUpdate.Staff.Add(staffToUpdate);
			
			await _goToMoUnitOfWork.SaveChangesAsync();
		}
	}
}
