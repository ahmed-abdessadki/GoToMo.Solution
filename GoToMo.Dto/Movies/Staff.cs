using GoToMo.Dto.Infrastructure;

namespace GoToMo.Dto.Movies
{
	public class Staff : Entity
	{
		public required string Name { get; set; }
		public StaffType StaffType { get; set; }	
	}
}
