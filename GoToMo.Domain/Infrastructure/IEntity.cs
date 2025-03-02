namespace GoToMo.Domain.Infrastructure
{
	public interface IEntity
	{
		int Id { get; }
		DateTimeOffset Created { get; set; }
		DateTimeOffset Modified { get; set; }
	}
}
