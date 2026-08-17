using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Interfaces;

namespace InventoryManager.Application
{
	public class CategoryService : ICategoryService
	{
		private readonly IRepository<Category> _repository;

		public CategoryService (IRepository<Category> repository)
		{
			_repository = repository;
		}

		public void AddCategory (Category category)
		{
			_repository.Add (category);
		}

		public IEnumerable<Category> GetCategories ()
		{
			return _repository.GetAll ();
		}

		public Category? GetById (int id)
		{
			return _repository.GetById (id);
		}
	}
}