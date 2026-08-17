using InventoryManager.Domain.Exceptions;

namespace InventoryManager.Domain.Entities
{
	public class Category
	{
		public int Id { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public bool IsActive { get; private set; }



		public void SetId (int id)
		{
			Id = id;
		}
		public Category (string name, string description)
		{
			Name = HandleName (name);
			Description = HandleDescription (description);
			IsActive = true;
		}

		public void Rename (string newName)
		{
			Name = HandleName (newName);
		}

		public void ChangeDescription (string newDescription)
		{
			Description = HandleDescription (newDescription);
		}

		public void Activate ()
		{
			IsActive = true;
		}

		public void Deactivate ()
		{
			IsActive = false;
		}

		private string HandleName (string name)
		{
			if (string.IsNullOrWhiteSpace (name))
			{
				throw new InvalidNameException ();
			}
			else
			{
				return name.Trim ();
			}
		}

		private string HandleDescription (string description)
		{
			if (string.IsNullOrWhiteSpace (description))
			{
				return string.Empty;
			}

			if (description.Length > 500)
			{
				throw new DescriptionTooLongException ();
			}

			return description.Trim ();
		}
	}
}