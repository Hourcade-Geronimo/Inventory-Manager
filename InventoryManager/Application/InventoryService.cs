using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Interfaces;

namespace InventoryManager.Application
{
	public class InventoryService : IInventoryService
	{
		private readonly IRepository<Product> _repository;

		public InventoryService(IRepository<Product> repository)
		{
			_repository = repository;
		}

		public void AddProduct(Product product)
		{
			_repository.Add(product);
		}

		public void DeleteProduct(string sku)
		{
			throw new NotImplementedException();
		}

		public Product GetBySku(string sku)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Product> GetProducts()
		{
			return _repository.GetAll();
		}

		public void UpdateStock(string sku, int quantity)
		{
			throw new NotImplementedException();
		}
	}
}