using GoToMo.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace GoToMo.Data.Repositories
{
	public class GenericRepository<T> : IRepository<T>
		where T : class
	{

		protected DbSet<T> DbSet { get; set; }

		protected GoToMoContext Context { get; set; }

		public GenericRepository(GoToMoContext context)
		{
			if (context == null)
			{
				throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
			}

			this.Context = context;
			this.DbSet = this.Context.Set<T>();

		}


		virtual public IQueryable<T> GetAll()
		{
			return this.DbSet;
		}

		virtual public async Task<T> GetByIdAsync(int id)
		{
			return await DbSet.FindAsync(id);
		}

		virtual public T GetById(int id)
		{
			return this.DbSet.Find(id);
		}

		virtual public T GetByIdWithRelatedObjects(int id, bool withTracking = true)
		{
			return this.DbSet.Find(id);
		}

		virtual public void Add(T entity)
		{
			var entry = this.Context.Entry(entity);
			if (entry.State != EntityState.Detached)
			{
				entry.State = EntityState.Added;
			}
			else
			{
				this.DbSet.Add(entity);
			}

		}

		public virtual void Update(T entity)
		{
			var entry = this.Context.Entry(entity);

			if (entry.State == EntityState.Detached)
			{
				this.DbSet.Attach(entity);
			}

			entry.State = EntityState.Modified;
		}

		virtual public void SetValues(T targetEntity, T sourceEntity)
		{
			this.Context.Entry(targetEntity).CurrentValues.SetValues(sourceEntity);

		}


		/// <summary>
		/// Query with dynamic Include
		/// </summary>
		/// <typeparam name="T">Entity</typeparam>
		/// <param name="context">dbContext</param>
		/// <param name="includeProperties">includeProperties with ; delimiters</param>
		/// <returns>Constructed query with include properties</returns>
		virtual public IQueryable<T> AsQueryable(string includeProperties = "", bool withTracking = false)
		{
			var query = withTracking ? this.DbSet.AsQueryable().AsTracking() : this.DbSet.AsQueryable().AsNoTracking();

			if (!String.IsNullOrWhiteSpace(includeProperties))
			{
				string[] includes = includeProperties.Split(';');
				foreach (string include in includes)
					query = query.Include(include);
			}

			return query;
		}


		virtual public void Delete(T entity)
		{

			var entry = this.Context.Entry(entity);
			if (entry.State != EntityState.Deleted)
			{
				entry.State = EntityState.Deleted;
			}
			else
			{
				this.DbSet.Attach(entity);
				this.DbSet.Remove(entity);
			}
		}

		virtual public void Delete(int id)
		{
			var entity = this.GetById(id);

			if (entity != null)
			{
				this.Delete(entity);
			}
		}

		public void Detach(T entity)
		{
			var entry = this.Context.Entry(entity);
			entry.State = EntityState.Detached;
		}
	}
}
