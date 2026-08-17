using InventoryManager.Application;
using InventoryManager.Domain.Entities;
using InventoryManager.Infrastructure.Repositories;

namespace InventoryManager
{
	public class Program
	{
		public static void Main (string [] args)
		{
			InMemoryProductRepository productRepository = new InMemoryProductRepository ();
			InMemoryCategoryRepository categoryRepository = new InMemoryCategoryRepository ();
			InventoryService productService = new InventoryService (productRepository);
			CategoryService categoryService = new CategoryService (categoryRepository);

			int opcion = 0;

			while (opcion != 5)
			{
				Console.Clear ();

				Console.WriteLine ("================================");
				Console.WriteLine ("      INVENTORY MANAGER");
				Console.WriteLine ("================================");
				Console.WriteLine ("1. Agregar producto");
				Console.WriteLine ("2. Agregar categoría");
				Console.WriteLine ("3. Listar productos");
				Console.WriteLine ("4. Listar categorías");
				Console.WriteLine ("5. Salir");
				Console.WriteLine ("================================");
				Console.Write ("Elegí una opción: ");

				if (!int.TryParse (Console.ReadLine (), out opcion))
				{
					Console.WriteLine ("Opción inválida.");
					Console.ReadLine ();
					continue;
				}

				switch (opcion)
				{
					// =========================================
					// AGREGAR PRODUCTO
					// =========================================
					case 1:
					{
						Console.Clear ();

						IEnumerable<Category> categories = categoryService.GetCategories ();

						if (!categories.Any ())
						{
							Console.WriteLine ("No podés crear un producto.");
							Console.WriteLine ("Primero tenés que crear al menos una categoría.");
							break;
						}

						Console.WriteLine ("=== AGREGAR PRODUCTO ===");
						Console.WriteLine ();

						Console.WriteLine ("¿A qué categoría pertenece?");
						Console.WriteLine ();

						foreach (Category category in categories)
						{
							Console.WriteLine ($"{category.Id}. {category.Name}");
						}

						Console.WriteLine ();
						Console.Write ("ID de categoría: ");

						if (!int.TryParse (Console.ReadLine (), out int categoryId))
						{
							Console.WriteLine ("ID inválido.");
							break;
						}

						Category? categorySelected = categoryService.GetById (categoryId);

						if (categorySelected == null)
						{
							Console.WriteLine (
								"No existe una categoría con ese ID."
							);
							break;
						}

						Console.WriteLine ();
						Console.Write ("Nombre: ");
						string name = Console.ReadLine ();

						Console.Write ("SKU: ");
						string sku = Console.ReadLine ();

						Console.Write ("Precio: ");

						if (!decimal.TryParse (Console.ReadLine (), out decimal price))
						{
							Console.WriteLine ("Precio inválido.");
							break;
						}

						Console.Write ("Stock: ");

						if (!int.TryParse (Console.ReadLine (), out int stock))
						{
							Console.WriteLine ("Stock inválido.");
							break;
						}

						try
						{
							Product product = new Product (
								categorySelected.Id,
								name,
								sku,
								price,
								stock
							);

							productService.AddProduct (product);

							Console.WriteLine ();
							Console.WriteLine ("Producto agregado correctamente.");
							Console.WriteLine (
								$"ID: {product.Id}"
							);
							Console.WriteLine (
								$"Categoría: {categorySelected.Name}"
							);
						}
						catch (Exception ex)
						{
							Console.WriteLine ();
							Console.WriteLine ($"Error: {ex.Message}");
						}

						break;
					}


					// =========================================
					// AGREGAR CATEGORÍA
					// =========================================
					case 2:
					{
						Console.Clear ();

						Console.WriteLine ("=== AGREGAR CATEGORÍA ===");
						Console.WriteLine ();

						Console.Write ("Nombre: ");
						string name = Console.ReadLine ();

						Console.Write ("Descripción: ");
						string description = Console.ReadLine ();

						try
						{
							Category category = new Category (name, description);

							categoryService.AddCategory (category);

							Console.WriteLine ();
							Console.WriteLine ("Categoría agregada correctamente.");
							Console.WriteLine ($"ID generado: {category.Id}");
						}
						catch (Exception ex)
						{
							Console.WriteLine ();
							Console.WriteLine ($"Error: {ex.Message}");
						}

						break;
					}


					// =========================================
					// LISTAR PRODUCTOS
					// =========================================
					case 3:
					{
						Console.Clear ();

						Console.WriteLine ("=== LISTADO DE PRODUCTOS ===");
						Console.WriteLine ();

						IEnumerable<Product> products = productService.GetProducts ();

						if (!products.Any ())
						{
							Console.WriteLine ("No hay productos registrados.");
							break;
						}

						foreach (Product product in products)
						{
							Category? category = categoryService.GetById (product.CategoryId);

							string categoryName = category?.Name ?? "Categoría no encontrada";

							Console.WriteLine (
								$"ID: {product.Id} | " +
								$"Nombre: {product.Name} | " +
								$"SKU: {product.Sku} | " +
								$"Precio: ${product.Price} | " +
								$"Stock: {product.Stock} | " +
								$"Categoría: {categoryName} " +
								$"(ID: {product.CategoryId})"
							);
						}

						break;
					}


					// =========================================
					// LISTAR CATEGORÍAS
					// =========================================
					case 4:
					{
						Console.Clear ();

						Console.WriteLine ("=== LISTADO DE CATEGORÍAS ===");
						Console.WriteLine ();

						IEnumerable<Category> categories = categoryService.GetCategories ();

						if (!categories.Any ())
						{
							Console.WriteLine ("No hay categorías registradas.");
							break;
						}

						foreach (Category category in categories)
						{
							Console.WriteLine (
								$"ID: {category.Id} | " +
								$"Nombre: {category.Name} | " +
								$"Descripción: {category.Description} | " +
								$"Activa: {category.IsActive}"
							);
						}

						break;
					}


					// =========================================
					// SALIR
					// =========================================
					case 5:
					{
						Console.WriteLine ();
						Console.WriteLine ("¡Hasta luego!");
						break;
					}


					default:
					{
						Console.WriteLine ();
						Console.WriteLine ("Opción inválida.");
						break;
					}
				}

				if (opcion != 5)
				{
					Console.WriteLine ();
					Console.WriteLine ("Presioná ENTER para continuar...");
					Console.ReadLine ();
				}
			}
		}
	}
}