using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Enums;
using InventoryManager.Domain.Exceptions;
using InventoryManager.Domain.Interfaces;

namespace InventoryManager.Application
{
	public class ProductService : IProductService
	{
		private readonly IRepository<Product> _repository;
		private readonly IStockMovementService _stockMovementService;

		public ProductService (IRepository<Product> repository, IStockMovementService stockMovementService)
		{
			_repository = repository;
			_stockMovementService = stockMovementService;
		}

		public void AddProduct (Product product)
		{
			StockMovement movement = new StockMovement (product.Id, product.Stock, MovementType.Entry, DateTime.UtcNow);

			_repository.Add (product);
			_stockMovementService.AddMovement (movement);
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
			Product? product = _repository.GetById (id);

			if (product == null)
			{
				return;
			}

			MovementType movementType;
			int movementQuantity;

			if (quantity > 0)
			{
				product.AddStock (quantity);

				movementType = MovementType.Entry;
				movementQuantity = quantity;
			}
			else if (quantity < 0)
			{
				int quantityToRemove = Math.Abs (quantity);

				product.RemoveStock (quantityToRemove);

				movementType = MovementType.Exit;
				movementQuantity = quantityToRemove;
			}
			else
			{
				throw new NegativeOrZeroQuantityException ();
			}

			_repository.Update (product);

			StockMovement movement = new StockMovement (product.Id, movementQuantity, movementType, DateTime.UtcNow);

			_stockMovementService.AddMovement (movement);
		}
	}
}