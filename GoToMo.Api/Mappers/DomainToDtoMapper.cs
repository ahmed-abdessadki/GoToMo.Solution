using AutoMapper;
using GoToMo.Domain.Movies;

namespace GoToMo.Api.Mappers
{
	public class DomainToDtoMappingProfile : Profile
	{
		public DomainToDtoMappingProfile()
		{
			CreateMap<Staff,Dto.Movies.Staff>();
			CreateMap<StreamingService, Dto.Movies.StreamingService>();
			CreateMap<Rating,Dto.Movies.Rating>();
			CreateMap<ProductionType, Dto.Movies.ProductionType>();
			CreateMap<StaffType, Dto.Movies.StaffType>();
			CreateMap<ProductionBundle, Dto.Movies.ProductionBundle>();
			CreateMap<Genre, Dto.Movies.Genre>();
			CreateMap<Production, Dto.Movies.Production>();
		}
	}
}
