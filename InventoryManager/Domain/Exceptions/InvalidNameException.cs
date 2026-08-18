namespace InventoryManager.Domain.Exceptions
{
	public class InvalidNameException : DomainException
	{
		public InvalidNameException () : base ("El nombre no puede estar vacío.")
		{
		}
	}
}