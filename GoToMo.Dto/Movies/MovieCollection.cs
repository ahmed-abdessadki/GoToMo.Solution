
using GoToMo.Dto.Infrastructure;
using GoToMo.Dto.Users;

namespace GoToMo.Dto.Movies
{
	public class MovieCollection : Entity
	{
		public required string Name { get; set; }
		public string? Description { get; set; }
		public List<Production>? Productions { get; set; }
		public User? Owner { get; set; }
		public List<User>? Users { get; set; }

	}
}
