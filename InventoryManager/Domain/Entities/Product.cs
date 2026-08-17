using InventoryManager.Domain.Exceptions;

namespace InventoryManager.Domain.Entities
{
	public class Product
	{

		public int Id {get; }
		public int CategoryId { get; private set; }
		public string Name {get; private set;}
		public string Sku { get;}
		public decimal Price {get; private set;}
		public int Stock {get; private set;}
		public bool IsActive {get; private set;}



		public Product(string name, string sku, decimal price, int stock, int categoryId, bool isActive)
		{
			HandleName(name);
			ChangePrice(price);
			AddStock(stock);
			Sku = HandleSku(sku);
			CategoryId = categoryId;
			IsActive = isActive;
		}

		public void ChangePrice(decimal newPrice)
		{
			if(newPrice <= 0)
			{
				throw new NegativeOrZeroPriceException();
			}
			else
			{
				Price = newPrice;
			}
		}

		public void AddStock(int quantity)
		{
			if(quantity < 0)
			{
				throw new NegativeOrZeroQuantityException();
			}
			else
			{
				Stock += quantity;	
			}
		
		}

		public void RemoveStock(int quantity)
		{
			if(quantity <= 0)
			{
				throw new NegativeOrZeroQuantityException();
			}
			else if (quantity > Stock)
			{
				throw new InsufficientStockException();		
			}
			else
			{
				Stock -= quantity;
			}
		}

		public void HandleName(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new InvalidProductNameException();

			Name = name.Trim();
		}

		public void Rename (string newName)
		{
			if (string.IsNullOrWhiteSpace (newName))
				throw new InvalidProductNameException();

			Name = newName;
		}

		private string HandleSku(string sku)
		{
			// todo: duplicated sku verification
			return sku;
		}
	}
}