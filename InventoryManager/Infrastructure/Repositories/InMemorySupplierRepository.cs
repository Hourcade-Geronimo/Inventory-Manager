using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Interfaces;

namespace InventoryManager.Infrastructure.Repositories
{
	public class InMemorySupplierRepository : IRepository<Supplier>
	{
		private readonly List<Supplier> _suppliers = new List<Supplier> ();
		private int _nextId = 1; // testing only, to delete after db exist

		public void Add (Supplier entity)
		{
			entity.SetId (_nextId);
			_nextId++;

			_suppliers.Add (entity);
		}

		public void Delete (int id)
		{
			Supplier? supplier = GetById (id);

			if (supplier != null)
			{
				_suppliers.Remove (supplier);
			}
		}

		public IEnumerable<Supplier> GetAll ()
		{
			return _suppliers;
		}

		public Supplier? GetById (int id)
		{
			return _suppliers.FirstOrDefault (s => s.Id == id);
		}

		public void Update (Supplier entity)
		{
			Supplier? supplier = GetById (entity.Id);

			if (supplier != null)
			{
				int index = _suppliers.IndexOf (supplier);
				_suppliers [index] = entity;
			}
		}
	}
}