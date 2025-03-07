using AutoMapper;
using GoToMo.Api.Application.Commands.Movies;
using GoToMo.Api.CQRS;
using GoToMo.Data.EF;
using GoToMo.Data.Repositories;
using GoToMo.Domain.Movies;
using GoToMo.Dto.Movies.CRUD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoToMo.Api.Controllers
{

	public class ProductionsController : ApiControllerBase
	{
		ICommandHandlerAsync<AddProductionStaffCommand> _addProductionStaffCommandHandler;
		ICommandHandlerAsync<AddProductionCommand, Production> _addProductionCommandHandler;

		public ProductionsController(GoToMoUnitOfWork goToMoUnitOfWork, IMapper mapper, ICommandHandlerAsync<AddProductionStaffCommand> addProductionStaffCommandHandler, ICommandHandlerAsync<AddProductionCommand, Production> addProductionCommandHandler) : base(goToMoUnitOfWork, mapper)
		{
			_addProductionStaffCommandHandler = addProductionStaffCommandHandler;
			_addProductionCommandHandler = addProductionCommandHandler;
		}

		[HttpPost("{id}/staff/{staffId}")]
		public async Task<IActionResult> AddProductionStaff(int id, int staffId)
		{
			var command = new AddProductionStaffCommand(id, staffId);
			await _addProductionStaffCommandHandler.HandleAsync(command);			
			return Ok();
		}

		[HttpPost]
		public async Task<ActionResult<Dto.Movies.Production>> Post(AddProduction addProduction)
		{
			var primaryGenre = (Domain.Movies.Genre) (addProduction.PrimaryGenre?? 0);
			var secondaryGenre = (Domain.Movies.Genre)(addProduction.SecondaryGenre ?? 0);
			var sequenceIndex = addProduction.SequenceIndex ?? 1;

			var command = new AddProductionCommand(addProduction.Title, (Domain.Movies.ProductionType)addProduction.ProductionType, addProduction.Url, addProduction.Plot, addProduction.ReleaseYear, addProduction.LengthInMinutes, primaryGenre, secondaryGenre, sequenceIndex, addProduction.Season);
			var newProduction = await _addProductionCommandHandler.HandleAsync(command);
			return CreatedAtAction("GetProduction", new { id = newProduction.Id }, _mapper.Map<Dto.Movies.Production>(newProduction));
		}


		[HttpGet("{id}")]
		public async Task<ActionResult<Dto.Movies.Production>> GetProduction(int id)
		{
			var production = await _goToMoUnitOfWork.Productions.GetByIdAsync(id);
			return Ok(_mapper.Map<Dto.Movies.Production>(production));
		}


		[HttpGet]
		public async Task<ActionResult<IEnumerable<Dto.Movies.Production>>> GetProductions()
		{
			var productions = _goToMoUnitOfWork.Productions.GetAll();
			return Ok(_mapper.Map<IEnumerable<Dto.Movies.Production>>(productions));
		}
	}
}
