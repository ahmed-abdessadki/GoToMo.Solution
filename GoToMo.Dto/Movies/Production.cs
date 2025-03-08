using GoToMo.Dto.Infrastructure;

namespace GoToMo.Dto.Movies
{
	public class Production : Entity
	{

		public required string Title { get; set; }
		public ProductionType ProductionType { get; set; }
		public string? Plot { get; set; }
		public string? Url { get; set; }
		public List<Staff> Staff { get; set; } = new();
		public List<StreamingService> StreamingServices { get; set; } = new();
		public int? ReleaseYear { get; init; }
		public int? LengthInMinutes { get; init; }
		public Genre PrimaryGenre { get; set; }
		public Genre SecondaryGenre { get; set; }		
		public int SequenceIndex { get; set; } = 1;
		public int? Season { get; set; }
		public ProductionBundle? Bundle { get; set; }
		public List<Rating>? Ratings { get; set; } = new();

	}
}
