using System.ComponentModel.DataAnnotations;

namespace GoToMo.Dto.Movies.CRUD
{
	public class AddProduction
	{
		[Required]
		public required string Title { get; set; }
		[Required]
		public ProductionType ProductionType { get; set; }
		public string? Url { get; set; }
		public string? Plot { get; set; }
		public int? ReleaseYear { get; init; }
		public int? LengthInMinutes { get; init; }
		public Genre? PrimaryGenre { get; set; }
		public Genre? SecondaryGenre { get; set; }		
		public int? SequenceIndex { get; set; } = 1;
		public int? Season { get; set; }				
	}
}
