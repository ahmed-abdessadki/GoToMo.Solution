using GoToMo.Data.EF;
using GoToMo.Domain.Movies;
using GoToMo.Domain.Users;

namespace GoToMo.Data.Repositories
{
	public class GoToMoUnitOfWork(GoToMoContext context) : IDisposable
	{
		GoToMoContext _context = context;
		IRepository<Production>? _productions;
		IRepository<Staff>? _staff;
		IRepository<User>? _users;
		IRepository<MovieCollection>? _movieCollections;
		IRepository<StreamingService>? _streamingServices;


		public IRepository<Production> Productions
		{
			get
			{
				if (this._productions == null)
				{
					this._productions = new GenericRepository<Production>(this._context);
				}

				return this._productions;
			}
		}


		public IRepository<Staff> Staff
		{
			get
			{
				if (this._staff == null)
				{
					this._staff = new GenericRepository<Staff>(this._context);
				}

				return this._staff;
			}
		}

		public IRepository<User> Users
		{
			get
			{
				if (this._users == null)
				{
					this._users = new GenericRepository<User>(this._context);
				}

				return this._users;
			}
		}

		public IRepository<MovieCollection> MovieCollections
		{
			get
			{
				if (this._movieCollections == null)
				{
					this._movieCollections = new GenericRepository<MovieCollection>(this._context);
				}

				return this._movieCollections;
			}
		}

		public IRepository<StreamingService> StreamingServices
		{
			get
			{
				if (this._streamingServices == null)
				{
					this._streamingServices = new GenericRepository<StreamingService>(this._context);
				}

				return this._streamingServices;
			}
		}


		public void Dispose()
		{
			_context?.Dispose();
		}
	}
}
