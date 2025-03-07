namespace GoToMo.Domain.Movies
{
	[Flags]
	public enum Genre
	{
		None = 0,
		Action = 1 << 0,
		Comedy = 1 << 1,
		Drama = 1 << 2,
		Horror = 1 << 3,
		SciFi = 1 << 4,
		Thriller = 1 << 5,
		Animation = 1 << 6,
		Crime = 1 << 7,
		Biography = 1 << 8
	}


}
