using System.ComponentModel.DataAnnotations;

namespace GoToMo.Dto.Movies.CRUD
{
	public class AddStaff
	{
		[Required]
		public string Name { get; set; }
		
		[Required]
		public StaffType StaffType { get; set; }

	}
}
