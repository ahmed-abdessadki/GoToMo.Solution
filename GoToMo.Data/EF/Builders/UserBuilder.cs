using GoToMo.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace GoToMo.Data.EF.Builders
{
	internal class UserBuilder : IEntityTypeConfiguration<User>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
		{
			builder.ToTable("User");			
		}
	}
}
