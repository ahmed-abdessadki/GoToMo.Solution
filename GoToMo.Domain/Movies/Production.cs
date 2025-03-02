using GoToMo.Domain.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace GoToMo.Domain.Movies
{
	public class Production : Entity
	{
		public string Title { get; set; }
		public Staff? Director { get; set; }
		public List<Staff>? Actors { get; set; }
		public List<StreamingService>? StreamingServices { get; set; }
		public int? Year { get; init; }
		public int? LengthInMinutes { get; init; }
		public Genre? PrimaryGenre { get; set; }
		public Genre? SecondaryGenre { get; set; }
		public ProductionType ProductionType { get; set; }
		public int SequenceIndex { get; set; } = 1;
		public int? Season { get; set; }
		public ProductionBundle? Bundle { get; set; }

		public List<Rating> Ratings { get; set; }

		public Production(string title, ProductionType productionType)
		{
			Title = title;
			ProductionType = productionType;
		}
	}
}
