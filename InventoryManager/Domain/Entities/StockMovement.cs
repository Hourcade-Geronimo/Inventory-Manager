using InventoryManager.Domain.Enums;
using InventoryManager.Domain.Exceptions;

namespace InventoryManager.Domain.Entities
{
	public class StockMovement
	{
		public int Id { get; private set; }
		public int ProductId { get; private set; }
		public int Quantity { get; private set; }
		public MovementType Type { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public StockMovement (int productId, int quantity, MovementType type, DateTime date)
		{
			ProductId = HandleProductId (productId);
			Quantity = HandleQuantity (quantity);
			Type = HandleType (type);
			CreatedAt = HandleDate (date);
		}

		public void SetId (int id)
		{
			Id = id;
		}

		private int HandleProductId (int productId)
		{
			if (productId <= 0)
			{
				throw new NegativeOrZeroIDException ();
			}

			return productId;
		}

		private int HandleQuantity (int quantity)
		{
			if (quantity <= 0)
			{
				throw new NegativeOrZeroQuantityException ();
			}

			return quantity;
		}

		private MovementType HandleType (MovementType type)
		{
			if (!Enum.IsDefined (typeof (MovementType), type))
			{
				throw new InvalidMovementTypeException ();
			}

			return type;
		}

		private DateTime HandleDate (DateTime date)
		{
			if (date == default)
			{
				throw new InvalidMovementDateException ();
			}

			return date;
		}
	}
}