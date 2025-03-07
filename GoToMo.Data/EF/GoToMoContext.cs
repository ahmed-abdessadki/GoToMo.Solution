using GoToMo.Data.EF.Builders;
using GoToMo.Domain.Movies;
using GoToMo.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace GoToMo.Data.EF
{
	public class GoToMoContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<MovieCollection> MovieCollections { get; set; }
		public DbSet<Production> Productions { get; set; }
		public DbSet<Staff> Staff { get; set; }
		public DbSet<StreamingService> StreamingServices { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new UserBuilder());
			modelBuilder.ApplyConfiguration(new ProductionBuilder());
			modelBuilder.ApplyConfiguration(new StreamingServiceBuilder());
			modelBuilder.ApplyConfiguration(new MovieCollectionBuilder());
		}

		public GoToMoContext(DbContextOptions<GoToMoContext> options): base(options)
		{
			ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}

		public override Task<int> SaveChangesAsync(
		   bool acceptAllChangesOnSuccess,
		   CancellationToken cancellationToken = default(CancellationToken))
		{

			var addedEntities = ChangeTracker.Entries()
				.Where(e => e.State == EntityState.Added)
				.ToList();

			addedEntities.ForEach(e =>
			{
				var now = DateTimeOffset.Now;
				if (e.CurrentValues.Properties.Any(p => p.Name == "Created"))
					e.Property("Created").CurrentValue = now;

				if (e.CurrentValues.Properties.Any(p => p.Name == "Modified"))
					e.Property("Modified").CurrentValue = now;

			});

			var editedEntities = ChangeTracker.Entries()
				.Where(e => e.State == EntityState.Modified)
				.ToList();

			editedEntities.ForEach(e =>
			{
				if (e.CurrentValues.Properties.Any(p => p.Name == "Modified"))
					e.Property("Modified").CurrentValue = DateTimeOffset.Now;
			});

			return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}
	}
}
