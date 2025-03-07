using GoToMo.Tests.Framework;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace GoToMo.Tests
{
	public class ProductionTests : TestBaseClass
	{
		[Test]
		public void TestListProductions()
		{
			var productions = ctx.Productions.Include(x => x.Ratings).ThenInclude(x => x.User).Include(x => x.Staff);
			foreach (var production in productions)
			{
				Console.WriteLine(production);
			}
		}
	}
}
