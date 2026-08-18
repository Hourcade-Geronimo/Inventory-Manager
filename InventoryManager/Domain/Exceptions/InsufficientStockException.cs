namespace InventoryManager.Domain.Exceptions
{
	public class InsufficientStockException : DomainException
	{
		public InsufficientStockException () : base ("No hay suficiente stock disponible.")
		{
		}
	}
}