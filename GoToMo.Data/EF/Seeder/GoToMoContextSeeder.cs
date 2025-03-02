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
					Year = 1994,
					Ratings = new List<Rating>
					{
						new Rating("IMDB", 9.3),
						new Rating("Rotten Tomatoes", 91),
						new Rating("Metacritic", 80),
						new Rating(9.5, ahmed),
						new Rating(9.0, johan),
						new Rating(8.5, niklas)
					},
					PrimaryGenre = Genre.Drama,
					SecondaryGenre = Genre.Crime,
					LengthInMinutes = 142,
					Actors = new List<Staff>
					{
						new Staff("Tim Robbins", StaffType.Actor),
						new Staff("Morgan Freeman", StaffType.Actor)
					},
					Director = new Staff("Frank Darabont", StaffType.Director),
					StreamingServices = new List<StreamingService>
					{
						GetStreamingService("Netflix"),
						GetStreamingService("HBO")
					}
				},
				new Production("The Godfather", ProductionType.Movie)
				{
					Year = 1972,
					Ratings = new List<Rating>
					{
						new Rating("IMDB", 9.2),
						new Rating("Rotten Tomatoes", 98),
						new Rating("Metacritic", 100)
					},
					PrimaryGenre = Genre.Drama,
					SecondaryGenre = Genre.Crime,
					LengthInMinutes = 175,
					Actors = new List<Staff>
					{
						new Staff("Marlon Brando", StaffType.Actor),
						new Staff("Al Pacino", StaffType.Actor)
					},
					Director = new Staff("Francis Ford Coppola", StaffType.Director),
					StreamingServices = new List<StreamingService>
					{
						GetStreamingService("Netflix"),
						GetStreamingService("HBO")
					}
				},
				new Production("The Dark Knight", ProductionType.Movie)
				{
					Year = 2008,
					Ratings = new List<Rating>
					{
						new Rating("IMDB", 9.0),
						new Rating("Rotten Tomatoes", 94),
						new Rating("Metacritic", 84)
					},
					PrimaryGenre = Genre.Action,
					SecondaryGenre = Genre.Drama,
					LengthInMinutes = 152,
					Actors = new List<Staff>
					{
						new Staff("Christian Bale", StaffType.Actor),
						new Staff("Heath Ledger", StaffType.Actor)
					},
					Director = new Staff("Christopher Nolan", StaffType.Director),
				},
				new Production("The Godfather: Part II", ProductionType.Movie)
				{
					Year = 1974,
					Ratings = new List<Rating>
					{
						new Rating("IMDB", 9.0),
						new Rating("Rotten Tomatoes", 97),
						new Rating("Metacritic", 90)
					},
					PrimaryGenre = Genre.Action,
					SecondaryGenre = Genre.Drama,
					LengthInMinutes = 202,
					Actors = new List<Staff>
					{
						new Staff("Al Pacino", StaffType.Actor),
						new Staff("Robert De Niro", StaffType.Actor)
					},
					Director = new Staff("Francis Ford Coppola", StaffType.Director),
				},
				new Production("The Lord of the Rings: The Return of the King", ProductionType.Movie)
				{
					Year = 2003,
					Ratings = new List<Rating>
					{
						new Rating("IMDB", 8.9),
						new Rating("Rotten Tomatoes", 93),
						new Rating("Metacritic", 94)
					},
					PrimaryGenre = Genre.Action,
					SecondaryGenre = Genre.Drama,
					LengthInMinutes = 201,
					Actors = new List<Staff>
					{
						new Staff("Elijah Wood", StaffType.Actor),
						new Staff("Viggo Mortensen", StaffType.Actor)
					},
					Director = new Staff("Peter Jackson", StaffType.Director)
				},
				new Production("Pulp Fiction", ProductionType.Movie)
				{
					Year = 2003,
					Ratings = new List<Rating>
					{
						new Rating("IMDB", 8.9),
						new Rating("Rotten Tomatoes", 92),
						new Rating("Metacritic", 94)
					},
					PrimaryGenre = Genre.Crime,
					SecondaryGenre = Genre.Drama,
					LengthInMinutes = 154,
					Actors = new List<Staff>
					{
						new Staff("John Travolta", StaffType.Actor),
						new Staff("Uma Thurman", StaffType.Actor)
					},
					Director = new Staff("Quentin Tarantino", StaffType.Director)
				},
				new Production("Schindler's List", ProductionType.Movie)
				{
					Year = 1993,
					Ratings = new List<Rating>
					{
						new Rating("IMDB", 8.9),
						new Rating("Rotten Tomatoes", 97),
						new Rating("Metacritic", 93)
					},
					PrimaryGenre = Genre.Biography,
					SecondaryGenre = Genre.Drama,
					LengthInMinutes = 195,
					Actors = new List<Staff>
					{
						new Staff("Liam Neeson", StaffType.Actor),
						new Staff("Ben Kingsley", StaffType.Actor)
					},
					Director = new Staff("Steven Spielberg", StaffType.Director)
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
