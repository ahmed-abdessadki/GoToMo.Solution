using AutoMapper;
using GoToMo.Api.Application.CommandHandlers.Movies;
using GoToMo.Api.Application.Commands.Movies;
using GoToMo.Api.CQRS;
using GoToMo.Api.Mappers;
using GoToMo.Data.Repositories;
using GoToMo.Domain.Movies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;
// Add services to the container.

builder.Services.AddScoped<GoToMoUnitOfWork>();
builder.Services.AddScoped<ICommandHandlerAsync<AddStaffCommand, Staff>, AddStaffCommandHandler>();
builder.Services.AddScoped<ICommandHandlerAsync<AddStreamingServiceCommand, StreamingService>, AddStreamingCommandHandler>();
builder.Services.AddScoped<ICommandHandlerAsync<AddProductionCommand, Production>, AddProductionCommandHandler>();
builder.Services.AddScoped<ICommandHandlerAsync<AddProductionStaffCommand>, AddProductionStaffCommandHandler>();
builder.Services.AddScoped<ICommandHandlerAsync<RemoveProductionStreamingServiceCommand>, RemoveProductionStreamingServiceCommandHandler>();
builder.Services.AddScoped<ICommandHandlerAsync<AddProductionStreamingServiceCommand>, AddProductionStreamingServiceCommandHandler>();
builder.Services.AddScoped<ICommandHandlerAsync<AddRatingCommand, Rating>, AddRatingCommandHandler>();
builder.Services.AddScoped<ICommandHandlerAsync<UpdateRatingCommand>, UpdateRatingCommandHandler>();
builder.Services.AddScoped<ICommandHandlerAsync<DeleteRatingCommand>, DeleteRatingCommandHandler>();

ICommandHandlerAsync<UpdateRatingCommand> _updateRatingCommandHandler;

var mapperConfig = new MapperConfiguration(mc =>
{
	mc.AddProfile(new DomainToDtoMappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

if (env.IsDevelopment())
{
	//configurationBuilder.AddApplicationInsightsSettings(true);
}

configurationBuilder.AddEnvironmentVariables();
var configuration = configurationBuilder.Build();

builder.Services.AddDbContext<GoToMo.Data.EF.GoToMoContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlDatabase")).EnableSensitiveDataLogging());

builder.Services.AddSignalR(o =>
{
	if (!builder.Environment.IsProduction())
		o.EnableDetailedErrors = true;
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(options =>
			options.WithOrigins("https://localhost:7048", "http://localhost:7048", "127.0.0.1", "10.0.2.2")
					.AllowAnyHeader()
					.AllowAnyMethod()
					.AllowCredentials()
			 );

using (var scope = app.Services.CreateScope())
{
	GoToMo.Data.EF.GoToMoContext dbContext = null;
	try
	{
		dbContext = scope.ServiceProvider.GetRequiredService<GoToMo.Data.EF.GoToMoContext>();
		if (dbContext.Database.GetPendingMigrations().Any())
			dbContext.Database.Migrate();
	}
	catch (Exception ex)
	{
		throw new ApplicationException("Error when migrate to latest version: " + ex);
	}
	finally
	{
		if (dbContext != null)
			dbContext.Dispose();
	}
}

app.Run();
