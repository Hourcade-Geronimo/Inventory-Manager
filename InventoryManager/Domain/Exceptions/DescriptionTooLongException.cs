namespace InventoryManager.Domain.Exceptions
{
	public class DescriptionTooLongException : DomainException
	{
		public DescriptionTooLongException () : base ("La descripción no puede superar los 500 caracteres.")
		{
		}
	}
}