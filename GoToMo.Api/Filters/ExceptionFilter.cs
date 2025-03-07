using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using GoToMo.Dto.Common;
using GoToMo.Domain.Infrastructure.Exceptions;

namespace GoToMo.Api.Filters
{
	public class ExceptionFilter : IExceptionFilter
	{
		public ExceptionFilter()
		{
		}
		public void OnException(ExceptionContext context)
		{
			ApiErrorResponse apiErrorResponse = null;
			var coachException = context.Exception as GoToMoBaseException;

			if (coachException is not null)
			{
				apiErrorResponse = new ApiErrorResponse(coachException.RootError.Code, coachException.RootError.Message);

				foreach (var error in coachException.AdditionalErrors)
				{
					apiErrorResponse.AddError(error.Code, error.Message);
				}
			}
			else
			{
				apiErrorResponse = new(100000, "A server side error occurred. Please contact support and provide the OperationId");
			}

			context.Result = new ObjectResult(apiErrorResponse);
			context.ExceptionHandled = true;

		}


		private string GetBody(ExceptionContext context)
		{

			//if (!String.IsNullOrEmpty(context.HttpContext?.Features.Get<RequestBodyFeature>()?.Body))
			//    return context.HttpContext?.Features.Get<RequestBodyFeature>()?.Body;

			//if (context.HttpContext != null && context.HttpContext.Items.ContainsKey("Body"))
			//    return context.HttpContext.GetItem("Body").ToString();

			return string.Empty;
		}

	}
}
