using InventoryManager.Domain.Entities;

public interface IInventoryService
{
	void AddProduct (Product product);

	IEnumerable<Product> GetProducts ();

	Product GetBySku (string sku);

	void UpdateStock (string sku, int quantity);

	void DeleteProduct (string sku);
}