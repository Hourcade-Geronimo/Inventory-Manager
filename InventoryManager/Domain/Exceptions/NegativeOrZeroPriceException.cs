namespace InventoryManager.Domain.Exceptions
{
	public class NegativeOrZeroPriceException : DomainException
	{
		public NegativeOrZeroPriceException () : base ("El precio debe ser mayor que cero.")
		{
		}
	}
}