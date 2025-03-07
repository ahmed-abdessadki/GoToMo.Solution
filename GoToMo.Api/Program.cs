using AutoMapper;
using GoToMo.Api.Application.CommandHandlers;
using GoToMo.Api.Application.Commands;
using GoToMo.Api.CQRS;
using GoToMo.Api.Mappers;
using GoToMo.Data.EF;
using GoToMo.Data.Repositories;
using GoToMo.Domain.Movies;
using GoToMo.Dto.Movies.CRUD;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;
// Add services to the container.

builder.Services.AddScoped<GoToMoUnitOfWork>();
builder.Services.AddScoped<ICommandHandlerAsync<AddStaffCommand, Staff>, AddStaffCommandHandler>();

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

builder.Services.AddDbContext<GoToMoContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlDatabase")).EnableSensitiveDataLogging());

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

using (var scope = app.Services.CreateScope())
{
	GoToMoContext dbContext = null;
	try
	{
		dbContext = scope.ServiceProvider.GetRequiredService<GoToMoContext>();
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
