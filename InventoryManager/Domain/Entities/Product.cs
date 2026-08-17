using InventoryManager.Domain.Exceptions;

namespace InventoryManager.Domain.Entities;

public class Product
{

	public int Id {get; }
	public string Name {get; private set;}
	public decimal Price {get; private set;}
	public int Stock {get; private set;}
	//public string Sku { get; }
	//public int CategoryId { get; private set; }



	public Product(string name, decimal price, int stock)
	{
		HandleName(name);
		ChangePrice(price);
		AddStock(stock);
		//Sku = sku;
		//CategoryId = categoryId;

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
}