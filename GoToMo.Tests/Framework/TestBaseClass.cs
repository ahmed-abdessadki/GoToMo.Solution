using GoToMo.Data.EF;
using GoToMo.Data.EF.Seeder;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoToMo.Tests.Framework
{
	[TestFixture]
	public class TestBaseClass
	{
		
		
		protected GoToMoContext ctx;

		[SetUp]
		public async Task SetUpAsync()
		{
			var dbOptionInMemory = new DbContextOptionsBuilder<GoToMoContext>()
			   .UseInMemoryDatabase("GotomoDb").EnableSensitiveDataLogging().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).Options;

			ctx = new GoToMoContext(dbOptionInMemory);
			ctx.Database.EnsureDeleted();
			ctx.Database.EnsureCreated();

			var seeder = new GoToMoContextSeeder(ctx);

			seeder.Seed();
		}
	}
}
