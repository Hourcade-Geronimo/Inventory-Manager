using InventoryManager.Domain.Exceptions;

namespace InventoryManager.Domain.Entities
{
	public class Product
	{
		public int Id { get; private set; }
		public int CategoryId { get; private set; }
		public int SupplierId { get; private set; }
		public string Name { get; private set; }
		public string Sku { get; private set; }
		public decimal Price { get; private set; }
		public int Stock { get; private set; }
		public bool IsActive { get; private set; }

		public Product (int categoryId, int supplierId, string name, string sku, decimal price, int stock)
		{
			Name = HandleName (name);
			Price = HandlePrice (price);
			Stock = HandleStock (stock);
			Sku = HandleSku (sku);
			CategoryId = HandleId (categoryId);
			SupplierId = HandleId (supplierId);
			IsActive = true;
		}

		public void SetId (int id)
		{
			Id = id;
		}

		private decimal HandlePrice (decimal price)
		{
			if (price <= 0)
			{
				throw new NegativeOrZeroPriceException ();
			}

			return price;
		}

		public void ChangePrice (decimal newPrice)
		{
			Price = HandlePrice (newPrice);
		}

		private int HandleStock (int stock)
		{
			if (stock < 0)
			{
				throw new NegativeOrZeroQuantityException ();
			}

			return stock;
		}

		public void AddStock (int quantity)
		{
			if (quantity <= 0)
			{
				throw new NegativeOrZeroQuantityException ();
			}

			Stock += quantity;
		}

		public void RemoveStock (int quantity)
		{
			if (quantity <= 0)
			{
				throw new NegativeOrZeroQuantityException ();
			}

			if (quantity > Stock)
			{
				throw new InsufficientStockException ();
			}

			Stock -= quantity;
		}

		private string HandleName (string name)
		{
			if (string.IsNullOrWhiteSpace (name))
			{
				throw new InvalidNameException ();
			}

			return name.Trim ();
		}

		public void Rename (string newName)
		{
			Name = HandleName (newName);
		}

		private string HandleSku (string sku)
		{
			if (string.IsNullOrWhiteSpace (sku))
			{
				throw new InvalidNameException ();
			}

			return sku.Trim ();
		}

		private int HandleId (int id)
		{
			if (id <= 0)
			{
				throw new NegativeOrZeroIDException ();
			}

			return id;
		}
	}
}