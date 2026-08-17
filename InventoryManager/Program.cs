using InventoryManager.Application;
using InventoryManager.Infrastructure.Repositories;

namespace InventoryManager
{
	public class Program
	{
		public static void Main(string[] args)
		{
			InMemoryProductRepository productRepository = new InMemoryProductRepository();
			InventoryService service = new InventoryService(productRepository);

			int opcion = 0;

			while (opcion != 3)
			{
				Console.Clear();

				Console.WriteLine("=== MENÚ DE PRODUCTOS ===");
				Console.WriteLine("1. Agregar producto");
				Console.WriteLine("2. Listar productos");
				Console.WriteLine("3. Salir");
				Console.Write("Elegí una opción: ");

				opcion = int.Parse(Console.ReadLine());

				switch (opcion)
				{
					case 1:
						Console.WriteLine("Agregando producto...");
						break;

					case 2:
						Console.WriteLine("Listado de productos...");
						break;

					case 3:
						Console.WriteLine("¡Hasta luego!");
						break;

					default:
						Console.WriteLine("Opción inválida.");
						break;
				}

				if (opcion != 3)
				{
					Console.WriteLine("\nPresioná ENTER para continuar...");
					Console.ReadLine();
				}
			}
		}
	}
}