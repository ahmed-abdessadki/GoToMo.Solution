using AutoMapper;
using GoToMo.Api.Application.Commands.Movies;
using GoToMo.Api.CQRS;
using GoToMo.Data.EF;
using GoToMo.Data.Repositories;
using GoToMo.Domain.Movies;
using GoToMo.Dto.Movies.CRUD;
using Microsoft.AspNetCore.Mvc;

namespace GoToMo.Api.Controllers
{
	public class StaffController : ApiControllerBase
	{
		ICommandHandlerAsync<AddStaffCommand, Staff> _addStaffCommandHandler;
		public StaffController(GoToMoUnitOfWork gotoMoUnitOfWork, IMapper mapper, ICommandHandlerAsync<AddStaffCommand, Staff> addStaffCommandHandler) : base(gotoMoUnitOfWork, mapper)
		{
			_addStaffCommandHandler = addStaffCommandHandler;
		}

		[HttpPost]
		public async Task<ActionResult<Dto.Movies.Staff>> Post(AddStaff addStaff)
		{
			var command = new AddStaffCommand(addStaff.Name, (Domain.Movies.StaffType)addStaff.StaffType);
			var newStaff = await _addStaffCommandHandler.HandleAsync(command);
			return CreatedAtAction("GetStaff", new { id = newStaff.Id }, _mapper.Map<Dto.Movies.Staff>(newStaff));
		}
		
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Dto.Movies.Staff>>> GetStaff()
		{
			var staff = _goToMoUnitOfWork.Staff.GetAll();
			return Ok(_mapper.Map<IEnumerable<Dto.Movies.Staff>>(staff));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<IEnumerable<Dto.Movies.Staff>>> GetStaff(int id)
		{
			var staff = _goToMoUnitOfWork.Staff.GetAll();
			return Ok(_mapper.Map<IEnumerable<Dto.Movies.Staff>>(staff));
		}



	}
}
