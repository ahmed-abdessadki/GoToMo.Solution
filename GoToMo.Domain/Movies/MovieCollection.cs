using GoToMo.Domain.Infrastructure;
using GoToMo.Domain.Users;

namespace GoToMo.Domain.Movies
{
	public class MovieCollection : Entity
	{
		public string Name { get; set; }
		public string? Description { get; set; }
		public List<Production> Productions { get; set; } = new();
		public User? Owner { get; set; }
		public List<User> Users { get; set; } = new();
		

		public MovieCollection(string name)
		{
			Name = name;
		}
	}
}
