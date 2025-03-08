using GoToMo.Domain.Movies;
using GoToMo.Domain.Users;

namespace GoToMo.Data.EF.Seeder
{
	public class GoToMoContextSeeder
	{
		private readonly GoToMoContext _ctx;
		private List<User> _users;
		private List<Production> _productions;
		private List<MovieCollection> _movieCollections;

		public GoToMoContextSeeder(GoToMoContext context)
		{
			_ctx = context;
			_users = new List<User>();
			_productions = new List<Production>();
			_movieCollections = new List<MovieCollection>();
		}
		public void Seed()
		{
			_ctx.Database.EnsureCreated();
			_users = GetSampleUsers();
			_productions = GetSampleProductions();
			_movieCollections = GetSampleMovieCollections();

			_ctx.Users.AddRange(_users);
			_ctx.Productions.AddRange(_productions);
			_ctx.MovieCollections.AddRange(_movieCollections);
			_ctx.SaveChanges();
		}

		private List<User> GetSampleUsers()
		{
			var users = new List<User>
			{
				new User("Ahmed", "Abdessadki"),
				new User("Johan", "Söng"),
				new User("Niklas", "Noaksson")
			};

			return users;
		}

		private List<StreamingService> GetStreamingServices()
		{
			var streamingServices = new List<StreamingService>
			{
				new StreamingService("Netflix", "https://www.netflix.com"),
				new StreamingService("HBO", "https://www.hbo.com"),
				new StreamingService("Amazon Prime", "https://www.amazon.com/prime")
			};
			return streamingServices;
		}

		private StreamingService GetStreamingService(string name)
		{
			return GetStreamingServices().Find(x => x.Name == name);
		}


		private List<Production> GetSampleProductions()
		{
			var ahmed = _users.Find(x => x.FirstName == "Ahmed")!;
			var johan = _users.Find(x => x.FirstName == "Johan")!;
			var niklas = _users.Find(x => x.FirstName == "Niklas")!;

			var productions = new List<Production>
			{
				new Production("The Shawshank Redemption", ProductionType.Movie)
				{
					ReleaseYear = 1994,
					Ratings = new List<Rating>
					{
						new Rating(9.3, "IMDB"),
						new Rating(91, "Rotten Tomatoes"),
						new Rating(80, "Metacritic"),
						new Rating(9.5, ahmed),
						new Rating(9.0, johan),
						new Rating(8.5, niklas)
					},
					PrimaryGenre = Genre.Drama,
					SecondaryGenre = Genre.Crime,
					LengthInMinutes = 142,
					Staff = new List<Staff>
					{
						new Staff("Tim Robbins", StaffType.Actor),
						new Staff("Morgan Freeman", StaffType.Actor)
					},
					//Director = new Staff("Frank Darabont", StaffType.Director),
					StreamingServices = new List<StreamingService>
					{
						GetStreamingService("Netflix"),
						GetStreamingService("HBO")
					}
				},
				new Production("The Godfather", ProductionType.Movie)
				{
					ReleaseYear = 1972,
					Ratings = new List<Rating>
					{
						new Rating(9.2, "IMDB"),
						new Rating(98, "Rotten Tomatoes"),
						new Rating(100, "Metacritic")
					},
					PrimaryGenre = Genre.Drama,
					SecondaryGenre = Genre.Crime,
					LengthInMinutes = 175,
					Staff = new List<Staff>
					{
						new Staff("Marlon Brando", StaffType.Actor),
						new Staff("Al Pacino", StaffType.Actor)
					},
					//Director = new Staff("Francis Ford Coppola", StaffType.Director),
					StreamingServices = new List<StreamingService>
					{
						GetStreamingService("Netflix"),
						GetStreamingService("HBO")
					}
				},
				new Production("The Dark Knight", ProductionType.Movie)
				{
					ReleaseYear = 2008,
					Ratings = new List<Rating>
					{
						new Rating(9.0, "IMDB"),
						new Rating(94, "Rotten Tomatoes"),
						new Rating(84, "Metacritic")
					},
					PrimaryGenre = Genre.Action,
					SecondaryGenre = Genre.Drama,
					LengthInMinutes = 152,
					Staff = new List<Staff>
					{
						new Staff("Christian Bale", StaffType.Actor),
						new Staff("Heath Ledger", StaffType.Actor)
					},
					//Director = new Staff("Christopher Nolan", StaffType.Director),
				},
				new Production("The Godfather: Part II", ProductionType.Movie)
				{
					ReleaseYear = 1974,
					Ratings = new List<Rating>
					{
						new Rating(9.0, "IMDB"),
						new Rating(97, "Rotten Tomatoes"),
						new Rating(90, "Metacritic")
					},
					PrimaryGenre = Genre.Action,
					SecondaryGenre = Genre.Drama,
					LengthInMinutes = 202,
					Staff = new List<Staff>
					{
						new Staff("Al Pacino", StaffType.Actor),
						new Staff("Robert De Niro", StaffType.Actor)
					},
					//Director = new Staff("Francis Ford Coppola", StaffType.Director),
				},
				new Production("The Lord of the Rings: The Return of the King", ProductionType.Movie)
				{
					ReleaseYear = 2003,
					Ratings = new List<Rating>
					{
						new Rating(8.9, "IMDB"),
						new Rating(93, "Rotten Tomatoes"),
						new Rating(94, "Metacritic")
					},
					PrimaryGenre = Genre.Action,
					SecondaryGenre = Genre.Drama,
					LengthInMinutes = 201,
					Staff = new List<Staff>
					{
						new Staff("Elijah Wood", StaffType.Actor),
						new Staff("Viggo Mortensen", StaffType.Actor)
					},
					//Director = new Staff("Peter Jackson", StaffType.Director)
				},
				new Production("Pulp Fiction", ProductionType.Movie)
				{
					ReleaseYear = 2003,
					Ratings = new List<Rating>
					{
						new Rating(8.9, "IMDB"),
						new Rating(92, "Rotten Tomatoes"),
						new Rating(94, "Metacritic")
					},
					PrimaryGenre = Genre.Crime,
					SecondaryGenre = Genre.Drama,
					LengthInMinutes = 154,
					Staff = new List<Staff>
					{
						new Staff("John Travolta", StaffType.Actor),
						new Staff("Uma Thurman", StaffType.Actor)
					},
					//Director = new Staff("Quentin Tarantino", StaffType.Director)
				},
				new Production("Schindler's List", ProductionType.Movie)
				{
					ReleaseYear = 1993,
					Ratings = new List<Rating>
					{
						new Rating(8.9, "IMDB"),
						new Rating(97, "Rotten Tomatoes"),
						new Rating(93, "Metacritic")
					},
					PrimaryGenre = Genre.Biography,
					SecondaryGenre = Genre.Drama,
					LengthInMinutes = 195,
					Staff = new List<Staff>
					{
						new Staff("Liam Neeson", StaffType.Actor),
						new Staff("Ben Kingsley", StaffType.Actor)
					},
					//Director = new Staff("Steven Spielberg", StaffType.Director)
				}
			};

			return productions;

		}

		private List<MovieCollection> GetSampleMovieCollections()
		{
			var movieCollections = new List<MovieCollection>
			{
				new MovieCollection("Top Movies of All Time")
				{
					Productions = new List<Production>
					{
						_productions.Find(x => x.Title == "The Shawshank Redemption")!,
						_productions.Find(x => x.Title == "The Godfather")!,
						_productions.Find(x => x.Title == "The Dark Knight")!,
						_productions.Find(x => x.Title == "The Godfather: Part II")!,
						_productions.Find(x => x.Title == "The Lord of the Rings: The Return of the King")!,
						_productions.Find(x => x.Title == "Pulp Fiction")!,
						_productions.Find(x => x.Title == "Schindler's List")!
					},
					Users = new List<User>
					{
						_users.Find(x => x.FirstName == "Ahmed")!,
						_users.Find(x => x.FirstName == "Johan")!,
						_users.Find(x => x.FirstName == "Niklas")!
					}
				}
			};
			return movieCollections;
		}
	}
}
