using InventoryManager.Domain.Entities;

public interface IStockMovementService
{
	void AddMovement (StockMovement movement);
	IEnumerable<StockMovement> GetMovements ();
	IEnumerable<StockMovement> GetByProductId (int productId);
}