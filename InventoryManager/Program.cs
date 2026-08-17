using InventoryManager.Application;
using InventoryManager.Domain.Entities;
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
					{
						Console.Write("Nombre: ");
						string name = Console.ReadLine();

						Console.Write("SKU: ");
						string sku = Console.ReadLine();

						Console.Write("Precio: ");
						decimal price = decimal.Parse(Console.ReadLine());

						Console.Write("Stock: ");
						int stock = int.Parse(Console.ReadLine());

						Product product = new Product(name, sku, price, stock);

						service.AddProduct(product);

						Console.WriteLine("Producto agregado correctamente.");
						break;
					}
					case 2:
					{
						Console.WriteLine("=== LISTADO DE PRODUCTOS ===");

						IEnumerable<Product> products = service.GetProducts();
						if (!products.Any())
						{
							Console.WriteLine("No hay productos registrados.");
							break;
						}
						foreach (Product product in products)
						{
							Console.WriteLine(
								$"Nombre: {product.Name} | " +
								$"SKU: {product.Sku} | " +
								$"Precio: ${product.Price} | " +
								$"Stock: {product.Stock}"
							);
						}

						break;
					}
					case 3:
					{
						Console.WriteLine("¡Hasta luego!");
							break;
					}

					default:
					{
						Console.WriteLine("Opción inválida.");
							break;
					}
				}

				if (opcion != 3)
				{
					Console.WriteLine("\nPresioná ENTER para continuar...\n");
					Console.ReadLine();
				}
			}
		}
	}
}