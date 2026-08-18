namespace InventoryManager.Domain.Exceptions
{
	public class NegativeOrZeroQuantityException : DomainException
	{
		public NegativeOrZeroQuantityException () : base ("La cantidad debe ser mayor que cero.")
		{
		}
	}
}