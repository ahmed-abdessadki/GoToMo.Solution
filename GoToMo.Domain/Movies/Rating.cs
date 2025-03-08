using GoToMo.Domain.Infrastructure;
using GoToMo.Domain.Users;

namespace GoToMo.Domain.Movies
{
	public class Rating : Entity
	{		
		public double RatingValue { get; set; }		
		public string Source { get; set; }
		public User? User { get; set; }

		
		public Rating(double ratingValue, string source)
		{			
			RatingValue = ratingValue;
			Source = source;
		}

		public Rating(double ratingValue, User user)
		{
			Source = "User";
			RatingValue = ratingValue;
			User = user;
		}
	}
}
