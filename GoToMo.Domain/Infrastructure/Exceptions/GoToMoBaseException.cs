using GoToMo.Domain.Common;

namespace GoToMo.Domain.Infrastructure.Exceptions
{
	public class GoToMoBaseException : Exception
	{		

		public Error RootError { get; }

		public List<Error> AdditionalErrors { get; } = new List<Error>();

		public GoToMoBaseException(string message, int code, Exception innerException) : base(message, innerException)
		{
			RootError = new Error(code, message);
		}
	
		public void AddError(params Error[] errors)
		{
			AdditionalErrors.AddRange(errors);
		}
	}
}
