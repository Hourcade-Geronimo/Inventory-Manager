using InventoryManager.Domain.Entities;

namespace InventoryManager.Application
{
	public interface ICategoryService
	{
		void AddCategory (Category category);

		IEnumerable<Category> GetCategories ();

		Category? GetById (int id);
	}
}