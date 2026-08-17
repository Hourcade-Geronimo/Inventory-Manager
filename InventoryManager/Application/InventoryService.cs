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

		public void AddProduct (Product product)
		{
			throw new NotImplementedException ();
		}

		public void DeleteProduct (string sku)
		{
			throw new NotImplementedException ();
		}

		public Product GetBySku (string sku)
		{
			throw new NotImplementedException ();
		}

		public IEnumerable<Product> GetProducts ()
		{
			throw new NotImplementedException ();
		}

		public void UpdateStock (string sku, int quantity)
		{
			throw new NotImplementedException ();
		}
	}
}