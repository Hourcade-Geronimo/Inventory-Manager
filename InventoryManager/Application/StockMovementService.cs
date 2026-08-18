using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Interfaces;

namespace InventoryManager.Application
{
	public class StockMovementService : IStockMovementService
	{
		private readonly IRepository<StockMovement> _repository;

		public StockMovementService (
			IRepository<StockMovement> repository)
		{
			_repository = repository;
		}

		public void AddMovement (StockMovement movement)
		{
			_repository.Add (movement);
		}

		public IEnumerable<StockMovement> GetMovements ()
		{
			return _repository.GetAll ();
		}

		public IEnumerable<StockMovement> GetByProductId (int productId)
		{
			return _repository
				.GetAll ()
				.Where (m => m.ProductId == productId);
		}
	}
}