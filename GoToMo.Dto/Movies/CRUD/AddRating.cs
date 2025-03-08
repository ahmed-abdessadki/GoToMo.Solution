namespace GoToMo.Dto.Movies.CRUD
{
	public class AddRating
	{
		public double Rating { get; set; }
		public string? Source { get; set; }
		public int? UserId { get; set; }
	}
}
