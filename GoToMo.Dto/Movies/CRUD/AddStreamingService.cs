using System.ComponentModel.DataAnnotations;

namespace GoToMo.Dto.Movies.CRUD
{
	public class AddStreamingService
	{
		[Required]
		public required string Name { get; set; }

		[Required]
		public required string Url { get; set; }
	}
}
