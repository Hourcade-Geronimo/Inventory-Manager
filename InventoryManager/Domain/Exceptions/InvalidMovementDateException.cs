namespace InventoryManager.Domain.Exceptions
{
	public class InvalidMovementDateException : DomainException
	{
		public InvalidMovementDateException () : base ("La fecha del movimiento no es válida.")
		{
		}
	}
}