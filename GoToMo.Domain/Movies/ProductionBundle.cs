using GoToMo.Domain.Infrastructure;

namespace GoToMo.Domain.Movies
{
	public class ProductionBundle : Entity
	{
		public string? Name { get; set; }
		public int? NumberOfSeasons { get; set; }
		public int NumberOfProductions { get; set; }

		public ProductionBundle()
		{
			
		}

	}
}
