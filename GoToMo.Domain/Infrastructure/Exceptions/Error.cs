namespace GoToMo.Domain.Infrastructure.Exceptions
{
	public record Error(int Code, string Message)
	{
		public int Code { get; } = Code;
		public string Message { get; } = Message;
	}
}
