﻿using GoToMo.Dto.Infrastructure;

namespace GoToMo.Dto.Users
{
	public class User : Entity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public User(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}

	}
}
