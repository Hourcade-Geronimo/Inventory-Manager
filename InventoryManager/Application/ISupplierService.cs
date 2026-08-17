using InventoryManager.Domain.Entities;

namespace InventoryManager.Application
{
	public interface ISupplierService
	{
		void AddSupplier (Supplier supplier);
		IEnumerable<Supplier> GetSuppliers ();
		Supplier? GetById (int id);
		void UpdateSupplier (Supplier supplier);
		void DeleteSupplier (int id);
	}
}