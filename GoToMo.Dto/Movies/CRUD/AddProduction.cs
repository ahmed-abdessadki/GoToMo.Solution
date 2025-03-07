using System.ComponentModel.DataAnnotations;

namespace GoToMo.Dto.Movies.CRUD
{
	public class AddProduction
	{
		[Required]
		public required string Title { get; set; }
		[Required]
		public ProductionType ProductionType { get; set; }
		public int? DirectorId { get; set; }
		public List<int>? ActorIds { get; set; }
		public List<int>? StreamingServices { get; set; }
		public int? Year { get; init; }
		public int? LengthInMinutes { get; init; }
		public Genre? PrimaryGenre { get; set; }
		public Genre? SecondaryGenre { get; set; }		
		public int SequenceIndex { get; set; } = 1;
		public int? Season { get; set; }				
	}
}
