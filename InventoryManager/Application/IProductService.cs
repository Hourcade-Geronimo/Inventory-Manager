using InventoryManager.Domain.Entities;

namespace InventoryManager.Application
{
	public interface IProductService
	{
		void AddProduct (Product product);
		IEnumerable<Product> GetProducts ();
		Product? GetById (int id);
		void UpdateProduct (Product product);
		void DeleteProduct (int id);
		void UpdateStock (int id, int quantity);
	}
}