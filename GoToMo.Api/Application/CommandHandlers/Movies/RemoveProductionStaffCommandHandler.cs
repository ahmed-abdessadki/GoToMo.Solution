using GoToMo.Api.Application.Commands.Movies;
using GoToMo.Api.CQRS;
using GoToMo.Data.EF;
using GoToMo.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GoToMo.Api.Application.CommandHandlers.Movies
{
	public class RemoveProductionStaffCommandHandler : ICommandHandlerAsync<RemoveProductionStaffCommand>
	{
		GoToMoUnitOfWork _goToMoUnitOfWork;
		public RemoveProductionStaffCommandHandler(GoToMoUnitOfWork goToMoUnitOfWork)
		{
			_goToMoUnitOfWork = goToMoUnitOfWork;
		}
		public async Task HandleAsync(RemoveProductionStaffCommand command)
		{
			var production = await _goToMoUnitOfWork.Productions.AsQueryable().Include(p => p.Staff).FirstOrDefaultAsync(p => p.Id == command.ProductionId);
			if (production is null)
			{
				throw new Exception("Production not found");
			}
			var staff = production.Staff.FirstOrDefault(ps => ps.Id == command.StaffId);
			if (staff is null)
			{
				throw new Exception("Staff not found");
			}

			production.Staff.Remove(staff);
			
			await _goToMoUnitOfWork.SaveChangesAsync();
		}
	}
}
