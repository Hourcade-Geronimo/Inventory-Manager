using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Interfaces;

namespace InventoryManager.Infrastructure.Repositories
{
	public class InMemoryProductRepository : IRepository<Product>
	{
		private readonly List<Product> _products = new List<Product> ();
		private int _nextId = 1; //testing only, deleate after db exist

		public void Add (Product entity)
		{
			entity.SetId (_nextId); // testing only, to deleate after db exist
			_nextId++;

			_products.Add (entity);
		}

		public void Delete (int id)
		{
			Product? product = GetById (id);

			if (product != null)
			{
				_products.Remove (product);
			}
		}

		public IEnumerable<Product> GetAll ()
		{
			return _products;
		}

		public Product? GetById (int id)
		{
			return _products.FirstOrDefault (p => p.Id == id);
		}

		public void Update (Product entity)
		{
			Product? product = GetById (entity.Id);

			if (product != null)
			{
				int index = _products.IndexOf (product);
				_products [index] = entity;
			}
		}
	}
}
