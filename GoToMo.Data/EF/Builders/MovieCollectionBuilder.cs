using GoToMo.Domain.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoToMo.Data.EF.Builders
{
	internal class MovieCollectionBuilder : IEntityTypeConfiguration<MovieCollection>
	{
		public void Configure(EntityTypeBuilder<MovieCollection> builder)
		{
			builder.ToTable("MovieCollection");
		}
	}
}
