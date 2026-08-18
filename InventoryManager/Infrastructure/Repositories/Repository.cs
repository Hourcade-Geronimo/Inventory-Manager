using InventoryManager.Domain.Interfaces;
using InventoryManager.Infrastructure.Data;

namespace InventoryManager.Infrastructure.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly InventoryContext _context;

		public Repository (InventoryContext context)
		{
			_context = context;
		}

		public IEnumerable<T> GetAll ()
		{
			return _context.Set<T> ();
		}

		public T? GetById (int id)
		{
			return _context.Set<T> ().Find (id);
		}

		public void Add (T entity)
		{
			_context.Set<T> ().Add (entity);
			_context.SaveChanges ();
		}

		public void Update (T entity)
		{
			_context.Set<T> ().Update (entity);
			_context.SaveChanges ();
		}

		public void Delete (int id)
		{
			T? entity = GetById (id);

			if (entity != null)
			{
				_context.Set<T> ().Remove (entity);
				_context.SaveChanges ();
			}
		}
	}
}