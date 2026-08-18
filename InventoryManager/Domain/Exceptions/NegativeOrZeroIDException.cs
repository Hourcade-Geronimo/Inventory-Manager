namespace InventoryManager.Domain.Exceptions
{
	public class NegativeOrZeroIDException : DomainException
	{
		public NegativeOrZeroIDException () : base ("El ID debe ser mayor que cero.")
		{
		}
	}
}