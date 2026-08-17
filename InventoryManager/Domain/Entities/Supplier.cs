using InventoryManager.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace InventoryManager.Domain.Entities
{
	public class Supplier
	{
		public int Id { get; private set; }
		public string Name { get; private set; }
		public string Phone { get; private set; }
		public bool IsActive { get; private set; }

		public Supplier (string name, string phone)
		{
			Name = HandleName (name);
			Phone = HandlePhone (phone);
			IsActive = true;
		}

		public void SetId (int id)
		{
			Id = id;
		}
		public void Rename (string newName)
		{
			Name = HandleName (newName);
		}

		public void ChangePhone (string newPhone)
		{
			Phone = HandlePhone (newPhone);
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

		private string HandlePhone(string phone)
		{
			if (string.IsNullOrWhiteSpace (phone) || !Regex.IsMatch(phone.Trim(), @"^\+?[0-9]{7,15}$"))
			{
				throw new InvalidPhoneException ();
			}
			else
			{
				return phone.Trim ();
			}
		}
	}
}
