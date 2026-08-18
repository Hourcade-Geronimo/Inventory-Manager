using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Interfaces;

namespace InventoryManager.Infrastructure.Repositories
{
	public class InMemoryStockMovementRepository : IRepository<StockMovement>
	{
		private readonly List<StockMovement> _movements = new List<StockMovement> ();
		private int _nextId = 1; // testing only, to delete after db exist

		public void Add (StockMovement entity)
		{
			entity.SetId (_nextId);
			_nextId++;

			_movements.Add (entity);
		}

		public void Delete (int id)
		{
			StockMovement? movement = GetById (id);

			if (movement != null)
			{
				_movements.Remove (movement);
			}
		}

		public IEnumerable<StockMovement> GetAll ()
		{
			return _movements;
		}

		public StockMovement? GetById (int id)
		{
			return _movements.FirstOrDefault (m => m.Id == id);
		}

		public void Update (StockMovement entity)
		{
			StockMovement? movement = GetById (entity.Id);

			if (movement != null)
			{
				int index = _movements.IndexOf (movement);
				_movements [index] = entity;
			}
		}
	}
}