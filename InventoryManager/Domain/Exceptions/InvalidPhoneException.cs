namespace InventoryManager.Domain.Exceptions
{
	public class InvalidPhoneException : DomainException
	{
		public InvalidPhoneException () : base ("El número de teléfono no es válido.")
		{
		}
	}
}