using InventoryManager.Domain.Exceptions;

namespace InventoryManager.Domain.Entities
{
	public class Product
	{

		public int Id { get; private set; }
		public int CategoryId { get; }
		public string Name { get; private set; }
		public string Sku { get; }
		public decimal Price { get; private set; }
		public int Stock { get; private set; }
		public bool IsActive { get; private set; }



		public Product (int categoryId, string name, string sku, decimal price, int stock)
		{
			Name = HandleName (name);
			Price = HandlePrice (price);
			Stock = HandleStock (stock);
			Sku = HandleSku (sku);
			CategoryId = HandleCategoryId (categoryId);
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
			else
			{
				return price;
			}

		}

		public void ChangePrice (decimal newPrice)
		{
			if (newPrice <= 0)
			{
				throw new NegativeOrZeroPriceException ();
			}
			else
			{
				Price = newPrice;
			}
		}

		private int HandleStock (int stock)
		{
			if (stock < 0)
			{
				throw new NegativeOrZeroQuantityException ();
			}
			else
			{
				return stock;
			}
		}

		public void AddStock (int quantity)
		{
			if (quantity <= 0)
			{
				throw new NegativeOrZeroQuantityException ();
			}
			else
			{
				Stock += quantity;
			}
		}

		public void RemoveStock (int quantity)
		{
			if (quantity <= 0)
			{
				throw new NegativeOrZeroQuantityException ();
			}
			else if (quantity > Stock)
			{
				throw new InsufficientStockException ();
			}
			else
			{
				Stock -= quantity;
			}
		}

		private string HandleName (string name)
		{
			if (string.IsNullOrWhiteSpace (name))
			{
				throw new InvalidNameException ();
			}
			else
			{
				return name.Trim ();
			}
		}

		public void Rename (string newName)
		{
			if (string.IsNullOrWhiteSpace (newName))
			{
				throw new InvalidNameException ();
			}
			else
			{
				Name = newName.Trim ();
			}
		}

		private string HandleSku (string sku)
		{
			if (string.IsNullOrWhiteSpace (sku))
			{
				throw new InvalidNameException ();
			}
			else
			{
				return sku;
			}
		}

		private int HandleCategoryId (int categoryId)
		{
			if (categoryId <= 0)
			{
				throw new NegativeOrZeroIDException ();
			}
			else
			{
				return categoryId;
			}
		}
	}
}