using AutoMapper;
using GoToMo.Api.Application.Commands.Movies;
using GoToMo.Api.CQRS;
using GoToMo.Data.Repositories;
using GoToMo.Dto.Movies.CRUD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoToMo.Api.Controllers
{

	public class ProductionsController : ApiControllerBase
	{
		ICommandHandlerAsync<AddProductionStaffCommand> _addProductionStaffCommandHandler;
		ICommandHandlerAsync<AddProductionCommand, Domain.Movies.Production> _addProductionCommandHandler;
		ICommandHandlerAsync<RemoveProductionStreamingServiceCommand> _removeProductionStreamingServiceCommandHandler;
		ICommandHandlerAsync<AddProductionStreamingServiceCommand> _addProductionStreamingServiceCommandHandler;
		ICommandHandlerAsync<AddRatingCommand, Domain.Movies.Rating> _addRatingCommandHandler;
		ICommandHandlerAsync<UpdateRatingCommand> _updateRatingCommandHandler;
		ICommandHandlerAsync<DeleteRatingCommand> _deleteRatingCommandHandler;
		public ProductionsController(GoToMoUnitOfWork goToMoUnitOfWork, IMapper mapper, ICommandHandlerAsync<AddProductionStaffCommand> addProductionStaffCommandHandler, ICommandHandlerAsync<AddProductionCommand, Domain.Movies.Production> addProductionCommandHandler, ICommandHandlerAsync<RemoveProductionStreamingServiceCommand> removeProductionStreamingServiceCommandHandler, ICommandHandlerAsync<AddProductionStreamingServiceCommand> addProductionStreamingServiceCommandHandler, ICommandHandlerAsync<AddRatingCommand, Domain.Movies.Rating> addRatingCommandHandler, ICommandHandlerAsync<UpdateRatingCommand> updateRatingCommandHandler, ICommandHandlerAsync<DeleteRatingCommand> deleteRatingCommandHandler) : base(goToMoUnitOfWork, mapper)
		{
			_addProductionStaffCommandHandler = addProductionStaffCommandHandler;
			_addProductionCommandHandler = addProductionCommandHandler;
			_removeProductionStreamingServiceCommandHandler = removeProductionStreamingServiceCommandHandler;
			_addProductionStreamingServiceCommandHandler = addProductionStreamingServiceCommandHandler;
			_addRatingCommandHandler = addRatingCommandHandler;
			_updateRatingCommandHandler = updateRatingCommandHandler;
			_deleteRatingCommandHandler = deleteRatingCommandHandler;
		}


		[HttpPost("{id}/ratings")]
		public async Task<ActionResult<Dto.Movies.Rating>> AddRating(int id, AddRating addProductionRating)
		{
			var command = new AddRatingCommand(id, addProductionRating.Rating, addProductionRating.Source, addProductionRating.UserId);
			var newRating = await _addRatingCommandHandler.HandleAsync(command);
			return CreatedAtAction("GetRating", new { prouctionId = id,  id = newRating.Id }, _mapper.Map<Dto.Movies.Rating>(newRating));
		}

		[HttpPut("{productionId}/ratings/{id}")]
		public async Task<ActionResult> UpdateRating(int productionId,int id, UpdateRating updateRating)
		{
			var command = new UpdateRatingCommand(id, productionId, updateRating.Rating);
			await _updateRatingCommandHandler.HandleAsync(command);	
			return Ok();
		}


		[HttpDelete("{productionId}/ratings/{id}")]
		public async Task<ActionResult<Dto.Movies.Rating>> DeleteRating(int productionId, int id)
		{
			await _deleteRatingCommandHandler.HandleAsync(new DeleteRatingCommand(id, productionId));
			return NoContent();
		}

		[HttpGet("{productionId}/ratings/{id}")]
		public async Task<ActionResult<Dto.Movies.Rating>> GetRating(int productionId, int id)
		{
			var production = await _goToMoUnitOfWork.Productions.AsQueryable().Include(p => p.Ratings).FirstOrDefaultAsync(p => p.Id == productionId);
			
			if(production is null)
			{
				return NotFound();
			}
			var rating = production.Ratings.FirstOrDefault(r => r.Id == id);

			if (rating is null)
			{
				return NotFound();
			}
			return Ok(_mapper.Map<IEnumerable<Dto.Movies.Rating>>(rating));

		}


		[HttpPost("{id}/streamingservices/{streamingServiceId}")]
		public async Task<IActionResult> AddStreamingService(int id, int streamingServiceId)
		{
			var command = new AddProductionStreamingServiceCommand(id, streamingServiceId);
			await _addProductionStreamingServiceCommandHandler.HandleAsync(command);
			return Ok();
		}

		[HttpDelete("{id}/streamingservices/{streamingServiceId}")]
		public async Task<IActionResult> RemoveStreamingService(int id, int streamingServiceId)
		{
			var command = new RemoveProductionStreamingServiceCommand(id, streamingServiceId);
			await _removeProductionStreamingServiceCommandHandler.HandleAsync(command);
			return NoContent();
		}

		[HttpPost("{id}/staff/{staffId}")]
		public async Task<IActionResult> AddProductionStaff(int id, int staffId)
		{
			var command = new AddProductionStaffCommand(id, staffId);
			await _addProductionStaffCommandHandler.HandleAsync(command);			
			return Ok();
		}

		[HttpDelete("{id}/staff/{staffId}")]
		public async Task<IActionResult> RemoveProductionStaff(int id, int staffId)
		{
			var command = new AddProductionStaffCommand(id, staffId);
			await _addProductionStaffCommandHandler.HandleAsync(command);
			return NoContent();
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
			var production = await _goToMoUnitOfWork.Productions.AsQueryable().Include(x => x.Ratings).Include(x => x.StreamingServices).Include(x => x.Staff).SingleOrDefaultAsync(x => x.Id == id);
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
