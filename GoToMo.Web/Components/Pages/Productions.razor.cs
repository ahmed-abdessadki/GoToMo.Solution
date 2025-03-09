using BlazorBootstrap;
using GoToMo.Dto.Movies;
using GoToMo.Web.Services.Api;
using Microsoft.AspNetCore.Components;

namespace GoToMo.Web.Components.Pages
{
	public partial class Productions : ComponentBase
	{
		[Inject]
		public ProductionsService _productionsService { get; set; }


		BlazorBootstrap.Grid<Production> grid = default!;
		private IEnumerable<Production> productions = default!;

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			await base.OnAfterRenderAsync(firstRender);
		}

		private async Task<GridDataProviderResult<Production>> ProductionsDataProvider(GridDataProviderRequest<Production> request)
		{
			if (productions is null) // pull productions only one time for client-side filtering, sorting, and paging
				productions = await GetProductions(); // call a service or an API to pull the productions

			return await Task.FromResult(request.ApplyTo(productions));
		}

		private async Task<IEnumerable<Production>> GetProductions()
		{
			return await _productionsService.GetProductions();
		}
	}

	
}
