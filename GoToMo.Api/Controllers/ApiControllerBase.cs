using AutoMapper;
using GoToMo.Api.Filters;
using GoToMo.Data.EF;
using GoToMo.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GoToMo.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[TypeFilter(typeof(ExceptionFilter))]
	public class ApiControllerBase : ControllerBase
	{
		
		protected IMapper _mapper;
		protected GoToMoUnitOfWork _goToMoUnitOfWork;

		public ApiControllerBase(GoToMoUnitOfWork gotomoUnitOfWork, IMapper mapper)
		{
			_goToMoUnitOfWork = gotomoUnitOfWork;
			_mapper = mapper;
		}
		
	}
}
