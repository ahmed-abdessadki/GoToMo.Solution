using GoToMo.Domain.Infrastructure;
using GoToMo.Domain.Users;

namespace GoToMo.Domain.Movies
{
	public class Rating : Entity
	{		
		public double RatingValue { get; set; }		
		public string Source { get; set; }
		public User? User { get; set; }
		Production Production { get; set; }
		public Rating(string source, double ratingValue)
		{
			Source = source;
			RatingValue = ratingValue;
		}

		public Rating(double ratingValue, User user)
		{
			Source = "User";
			RatingValue = ratingValue;
			User = user;
		}
	}
}
