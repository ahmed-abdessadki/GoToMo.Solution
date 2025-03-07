using GoToMo.Domain.Movies;
using GoToMo.Tests.Framework;
using NUnit.Framework;
using System.Diagnostics;

namespace GoToMo.Tests
{
	public class GenreTests : TestBaseClass
	{

		[Test]
		public void TestGenre()
		{
			var actionAndSciFi = Genre.Action | Genre.SciFi;
			Debug.WriteLine(actionAndSciFi);
		}
	}
}
