using GoToMo.Dto.Movies;

namespace GoToMo.Web.Services.Api
{
	public class ProductionsService : ApiServiceBase
	{
		
		public ProductionsService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
		{
		}

		
		public async Task<List<Production>> GetProductions()
		{
			var productions = await _httpClient.GetFromJsonAsync<List<Production>>("api/productions");
			return productions ?? new List<Production>();

		}
	

		public async Task<Production> GetEquipmentById(int id)
		{
			var production = await _httpClient.GetFromJsonAsync<Production>($"api/productions/{id}");
			return production!;
		}
		
	}
	
}
