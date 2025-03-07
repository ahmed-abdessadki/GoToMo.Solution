using GoToMo.Domain.Infrastructure;

namespace GoToMo.Domain.Movies
{
	public class Staff : Entity
	{
		public string Name { get; set; }
		public StaffType StaffType { get; set; }

		public List<Production>? Productions { get; set; }

		public Staff(string name, StaffType staffType)
		{
			Name = name;
			StaffType = staffType;
		}
	}
}
