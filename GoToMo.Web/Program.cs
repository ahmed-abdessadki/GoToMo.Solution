using GoToMo.Web.Components;
using GoToMo.Web.Services.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBlazorBootstrap();
// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddHttpClient("MyHttpClient", client =>
{
	client.BaseAddress = new Uri("https://localhost:7250/");
	client.DefaultRequestHeaders.Add("Accept", "application/json");
	// Add other configuration settings here
});

builder.Services.AddScoped<ProductionsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
