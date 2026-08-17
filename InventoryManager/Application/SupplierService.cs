using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Interfaces;

namespace InventoryManager.Application
{
	public class SupplierService : ISupplierService
	{
		private readonly IRepository<Supplier> _repository;

		public SupplierService (IRepository<Supplier> repository)
		{
			_repository = repository;
		}

		public void AddSupplier (Supplier supplier)
		{
			_repository.Add (supplier);
		}

		public IEnumerable<Supplier> GetSuppliers ()
		{
			return _repository.GetAll ();
		}

		public Supplier? GetById (int id)
		{
			return _repository.GetById (id);
		}

		public void UpdateSupplier (Supplier supplier)
		{
			_repository.Update (supplier);
		}

		public void DeleteSupplier (int id)
		{
			_repository.Delete (id);
		}
	}
}