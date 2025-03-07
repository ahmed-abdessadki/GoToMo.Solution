using GoToMo.Dto.Infrastructure;
using GoToMo.Dto.Users;

namespace GoToMo.Dto.Movies
{
	public class Rating : Entity
	{		
		public double RatingValue { get; set; }		
		public required string Source { get; set; }
		public User? User { get; set; }
		public required Production Production { get; set; }
	
	}
}
