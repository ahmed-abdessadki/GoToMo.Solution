using GoToMo.Domain.Infrastructure;

namespace GoToMo.Domain.Users
{
	public class User : Entity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public User(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}

	}
}
