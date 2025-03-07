using GoToMo.Domain.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoToMo.Data.EF.Builders
{
	internal class ProductionBuilder : IEntityTypeConfiguration<Production>
	{
		public void Configure(EntityTypeBuilder<Production> builder)
		{
			builder.ToTable("Production");
		}
	}
}
