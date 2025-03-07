using AutoMapper;
using GoToMo.Api.Application.Commands.Movies;
using GoToMo.Api.CQRS;
using GoToMo.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GoToMo.Api.Controllers
{
	public class StreamingServicesController : ApiControllerBase
	{

		ICommandHandlerAsync<AddStreamingServiceCommand, Domain.Movies.StreamingService> _addStreamingServiceCommandHandler;


		public StreamingServicesController(GoToMoUnitOfWork gotomoUnitOfWork, IMapper mapper, ICommandHandlerAsync<AddStreamingServiceCommand, Domain.Movies.StreamingService> addStreamingServiceCommandHandler) : base(gotomoUnitOfWork, mapper)
		{
			_addStreamingServiceCommandHandler = addStreamingServiceCommandHandler;
		}


		[HttpGet]
		public async Task<ActionResult<IEnumerable<Dto.Movies.StreamingService>>> GetStreamingServices()
		{
			var streamingServices = _goToMoUnitOfWork.StreamingServices.GetAll();
			return Ok(_mapper.Map<IEnumerable<Dto.Movies.StreamingService>>(streamingServices));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<IEnumerable<Dto.Movies.StreamingService>>> GetStreamingService(int id)
		{
			var streamingServices = await _goToMoUnitOfWork.StreamingServices.GetByIdAsync(id);
			return Ok(_mapper.Map<Dto.Movies.StreamingService>(streamingServices));
		}


		[HttpPost]
		public async Task<ActionResult<Dto.Movies.StreamingService>> Post(AddStreamingServiceCommand addStreamingService)
		{
			var command = new AddStreamingServiceCommand(addStreamingService.Name, addStreamingService.Url);
			var newStreamingService = await _addStreamingServiceCommandHandler.HandleAsync(command);
			return CreatedAtAction("GetStreamingService", new { id = newStreamingService.Id }, _mapper.Map<Dto.Movies.StreamingService>(newStreamingService));
		}

	}
}
