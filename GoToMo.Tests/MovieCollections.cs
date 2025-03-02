using GoToMo.Tests.Framework;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace GoToMo.Tests
{
	public class MovieCollectionTests : TestBaseClass
	{
		[Test]
		public void TestListMovieCollections()
		{
			var movieCollections = ctx.MovieCollections.Include(x => x.Productions).Include(x => x.Users);
			foreach (var movieCollection in movieCollections)
			{
				Console.WriteLine(movieCollection);
			}
		}
	}
}
