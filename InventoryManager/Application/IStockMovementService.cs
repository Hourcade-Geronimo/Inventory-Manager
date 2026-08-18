using InventoryManager.Domain.Entities;

namespace InventoryManager.Application
{
	public interface IStockMovementService
	{
		void AddMovement (StockMovement movement);
		IEnumerable<StockMovement> GetMovements ();
		IEnumerable<StockMovement> GetByProductId (int productId);
	}
}