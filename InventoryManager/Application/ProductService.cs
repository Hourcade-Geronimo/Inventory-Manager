using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Interfaces;

namespace InventoryManager.Application
{
	public class ProductService : IProductService
	{
		private readonly IRepository<Product> _repository;

		public ProductService (IRepository<Product> repository)
		{
			_repository = repository;
		}

		public void AddProduct (Product product)
		{
			_repository.Add (product);
		}

		public IEnumerable<Product> GetProducts ()
		{
			return _repository.GetAll ();
		}

		public Product? GetById (int id)
		{
			return _repository.GetById (id);
		}

		public void UpdateProduct (Product product)
		{
			_repository.Update (product);
		}

		public void DeleteProduct (int id)
		{
			_repository.Delete (id);
		}

		public void UpdateStock (int id, int quantity)
		{
			throw new NotImplementedException ();
		}
	}
}