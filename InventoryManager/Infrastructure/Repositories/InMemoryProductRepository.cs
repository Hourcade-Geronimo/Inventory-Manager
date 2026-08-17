using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Interfaces;

namespace InventoryManager.Infrastructure.Repositories
{
	internal class InMemoryProductRepository : IRepository<Product>
	{
		public void Add (Product entity)
		{
			throw new NotImplementedException ();
		}

		public void Delete (int id)
		{
			throw new NotImplementedException ();
		}

		public IEnumerable<Product> GetAll ()
		{
			throw new NotImplementedException ();
		}

		public Product? GetById (int id)
		{
			throw new NotImplementedException ();
		}

		public void Update (Product entity)
		{
			throw new NotImplementedException ();
		}
	}
}
