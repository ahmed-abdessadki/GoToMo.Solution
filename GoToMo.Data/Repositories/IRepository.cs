namespace GoToMo.Data.Repositories
{
	public interface IRepository<T> where T : class
	{
		IQueryable<T> GetAll();
		T GetById(int id);
		Task<T> GetByIdAsync(int id);
		T GetByIdWithRelatedObjects(int id, bool withTracking = true);
		void Add(T entity);
		void Update(T entity);
		void SetValues(T targetEntitiy, T sourceEntity);
		void Delete(T entity);
		void Delete(int id);
		void Detach(T entity);
		IQueryable<T> AsQueryable(string includeProperties = "", bool withTracking = false);
	}
}
