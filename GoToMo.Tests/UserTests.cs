using GoToMo.Tests.Framework;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace GoToMo.Tests
{
	public class UserTests : TestBaseClass
	{
		[Test]
		public void TestListUsers()
		{
			var users = ctx.Users;
			foreach (var usr in users)
			{
				Console.WriteLine(usr);
			}
		}

		//[Test]
		//public void TestGetSpecificUser()
		//{
		//	var userId = 1;
		//	var unitOfWork = new CoachUnitOfWork(ctx);
		//	var ruleSets = unitOfWork.RuleSets.AsQueryable("Rules").Where(x => x.UserId == userId);

		//}
	}
}
