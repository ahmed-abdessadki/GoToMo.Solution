﻿using GoToMo.Api.Application.Commands.Movies;
using GoToMo.Api.CQRS;
using GoToMo.Data.Repositories;
using GoToMo.Domain.Movies;

namespace GoToMo.Api.Application.CommandHandlers.Movies
{
	public class AddStaffCommandHandler : ICommandHandlerAsync<AddStaffCommand, Staff>
	{
		GoToMoUnitOfWork _goToMoUnitOfWork;

		public AddStaffCommandHandler(GoToMoUnitOfWork goToMoUnitOfWork)
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
