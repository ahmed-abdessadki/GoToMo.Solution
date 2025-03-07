using AutoMapper;
using GoToMo.Data.EF;
using GoToMo.Data.Repositories;
using GoToMo.Dto.Movies.CRUD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoToMo.Api.Controllers
{

	public class ProductionsController : ApiControllerBase
	{
		public ProductionsController(GoToMoUnitOfWork goToMoUnitOfWork, IMapper mapper) : base(goToMoUnitOfWork, mapper)
		{
		}

		//[HttpPost]
		//public async Task<ActionResult<Dto.Movies.Production>> PostProduction(AddProduction addProduction)
		//{
		//	await _goToMoUnitOfWork.SaveChangesAsync();
		//	return CreatedAtAction("GetProduction", new { id = productionEntity.Id }, _mapper.Map<Dto.Movies.Production>(productionEntity));
		//}


		[HttpGet]
		public async Task<ActionResult<IEnumerable<Dto.Movies.Production>>> GetProductions()
		{
			var productions = _goToMoUnitOfWork.Productions.GetAll();
			return Ok(_mapper.Map<IEnumerable<Dto.Movies.Production>>(productions));
		}
	}
}
