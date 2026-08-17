using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Interfaces;

namespace InventoryManager.Infrastructure.Repositories
{
	public class InMemoryCategoryRepository : IRepository<Category>
	{
		private readonly List<Category> _categories = new List<Category> ();
		private int _nextId = 1; //testing only, to delete after db exist

		public void Add (Category entity)
		{
			entity.SetId (_nextId);// testing only to deleate after db
			_nextId++;

			_categories.Add (entity);
		}

		public void Delete (int id)
		{
			Category? category = GetById (id);

			if (category != null)
			{
				_categories.Remove (category);
			}
		}

		public IEnumerable<Category> GetAll ()
		{
			return _categories;
		}

		public Category? GetById (int id)
		{
			return _categories.FirstOrDefault (c => c.Id == id);
		}

		public void Update (Category entity)
		{
			Category category = GetById (entity.Id);

			if (category != null)
			{
				int index = _categories.IndexOf (category);
				_categories [index] = entity;
			}
		}
	}
}