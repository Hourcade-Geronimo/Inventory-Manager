namespace InventoryManager.Domain.Exceptions
{
	public class InvalidMovementTypeException : DomainException
	{
		public InvalidMovementTypeException () : base ("El tipo de movimiento no es válido.")
		{
		}
	}
}