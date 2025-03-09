using System.Text.Json;

namespace GoToMo.Web.Services.Api
{
	public abstract class ApiServiceBase
	{
		protected readonly HttpClient _httpClient;

		public ApiServiceBase(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("MyHttpClient");
		}

		private async Task ThrowExceptionIfError(HttpResponseMessage response)
		{
			if (!response.IsSuccessStatusCode)
			{
				//ErrorResponse? errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();

				throw new Exception(response.ReasonPhrase);

				
			}
		}

		protected async Task<T> HandleResponse<T>(HttpResponseMessage response)
		{

			await ThrowExceptionIfError(response);

			string content = await response.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<T>(content);

		}

		protected async Task<bool> HandleResponse(HttpResponseMessage response)
		{

			await ThrowExceptionIfError(response);

			return response.IsSuccessStatusCode;

		}



	}
}
