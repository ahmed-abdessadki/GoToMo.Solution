using GoToMo.Dto.Infrastructure;

namespace GoToMo.Dto.Movies
{
	public class ProductionBundle : Entity
	{
		public string? Name { get; set; }
		public int? NumberOfSeasons { get; set; }
		public int NumberOfProductions { get; set; }

	}
}
