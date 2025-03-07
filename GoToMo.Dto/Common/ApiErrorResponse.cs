namespace GoToMo.Dto.Common
{
	public class ApiErrorResponse
	{
		public int OperationId { get; set; }

		public Error RootError { get; set; }

		public List<Error> Errors { get; set; } = new();

		public ApiErrorResponse(int code, string message)
		{
			RootError = new Error(code, message);
		}
		public class Error
		{
			public int Code { get; set; }

			public string Message { get; set; }

			public Error(int code, string message)
			{
				Code = code;
				Message = message;
			}




		}

		public void AddError(int code, string message)
		{
			Errors.Add(new Error(code, message));
		}
	}
}
