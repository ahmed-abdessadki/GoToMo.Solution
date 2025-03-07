using GoToMo.Domain.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoToMo.Data.EF.Builders
{
	internal class StreamingServiceBuilder : IEntityTypeConfiguration<StreamingService>
	{
		public void Configure(EntityTypeBuilder<StreamingService> builder)
		{
			builder.ToTable("StreamingService");
		}
	}
}
