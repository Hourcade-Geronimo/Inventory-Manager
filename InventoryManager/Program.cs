using InventoryManager.Application;
using InventoryManager.Domain.Entities;
using InventoryManager.Infrastructure.Data;
using InventoryManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager
{
	public class Program
	{
		public static void Main (string [] args)
		{
			string databasePath = Path.Combine (AppContext.BaseDirectory, "inventory.db");

			DbContextOptions<InventoryContext> options =
				new DbContextOptionsBuilder<InventoryContext> ()
					.UseSqlite ($"Data Source={databasePath}")
					.Options;

			using InventoryContext context = new InventoryContext (options);

			context.Database.EnsureCreated ();

			Repository<Product> productRepository =
				new Repository<Product> (context);

			Repository<Category> categoryRepository =
				new Repository<Category> (context);

			Repository<Supplier> supplierRepository =
				new Repository<Supplier> (context);

			Repository<StockMovement> stockMovementRepository =
				new Repository<StockMovement> (context);

			StockMovementService stockMovementService =
				new StockMovementService (stockMovementRepository);

			ProductService productService =
				new ProductService (productRepository, stockMovementService);

			CategoryService categoryService =
				new CategoryService (categoryRepository);

			SupplierService supplierService =
				new SupplierService (supplierRepository);

			int opcion = 0;

			while (opcion != 10)
			{
				Console.Clear ();

				Console.WriteLine ("================================");
				Console.WriteLine ("      INVENTORY MANAGER");
				Console.WriteLine ("================================");
				Console.WriteLine ("1. Agregar producto");
				Console.WriteLine ("2. Agregar categoría");
				Console.WriteLine ("3. Agregar proveedor");
				Console.WriteLine ("4. Listar productos");
				Console.WriteLine ("5. Listar categorías");
				Console.WriteLine ("6. Listar proveedores");
				Console.WriteLine ("7. Agregar stock");
				Console.WriteLine ("8. Remover stock");
				Console.WriteLine ("9. Ver movimientos");
				Console.WriteLine ("10. Salir");
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

						IEnumerable<Category> categories =
							categoryService.GetCategories ();

						IEnumerable<Supplier> suppliers =
							supplierService.GetSuppliers ();

						if (!categories.Any ())
						{
							Console.WriteLine ("No podés crear un producto.");
							Console.WriteLine (
								"Primero tenés que crear al menos una categoría."
							);
							break;
						}

						if (!suppliers.Any ())
						{
							Console.WriteLine ("No podés crear un producto.");
							Console.WriteLine (
								"Primero tenés que crear al menos un proveedor."
							);
							break;
						}

						Console.WriteLine ("=== AGREGAR PRODUCTO ===");
						Console.WriteLine ();

						Console.WriteLine ("¿A qué categoría pertenece?");
						Console.WriteLine ();

						foreach (Category category in categories)
						{
							Console.WriteLine (
								$"{category.Id}. {category.Name}"
							);
						}

						Console.WriteLine ();
						Console.Write ("ID de categoría: ");

						if (!int.TryParse (
							Console.ReadLine (),
							out int categoryId))
						{
							Console.WriteLine ("ID inválido.");
							break;
						}

						Category? categorySelected =
							categoryService.GetById (categoryId);

						if (categorySelected == null)
						{
							Console.WriteLine (
								"No existe una categoría con ese ID."
							);
							break;
						}

						Console.WriteLine ();
						Console.WriteLine ("¿Cuál es el proveedor?");
						Console.WriteLine ();

						foreach (Supplier supplier in suppliers)
						{
							Console.WriteLine (
								$"{supplier.Id}. {supplier.Name} - {supplier.Phone}"
							);
						}

						Console.WriteLine ();
						Console.Write ("ID de proveedor: ");

						if (!int.TryParse (
							Console.ReadLine (),
							out int supplierId))
						{
							Console.WriteLine ("ID inválido.");
							break;
						}

						Supplier? supplierSelected =
							supplierService.GetById (supplierId);

						if (supplierSelected == null)
						{
							Console.WriteLine (
								"No existe un proveedor con ese ID."
							);
							break;
						}

						Console.WriteLine ();
						Console.Write ("Nombre: ");
						string name = Console.ReadLine ();

						Console.Write ("SKU: ");
						string sku = Console.ReadLine ();

						Console.Write ("Precio: ");

						if (!decimal.TryParse (
							Console.ReadLine (),
							out decimal price))
						{
							Console.WriteLine ("Precio inválido.");
							break;
						}

						Console.Write ("Stock: ");

						if (!int.TryParse (
							Console.ReadLine (),
							out int stock))
						{
							Console.WriteLine ("Stock inválido.");
							break;
						}

						try
						{
							Product product = new Product (
								categorySelected.Id,
								supplierSelected.Id,
								name,
								sku,
								price,
								stock
							);

							productService.AddProduct (product);

							Console.WriteLine ();
							Console.WriteLine (
								"Producto agregado correctamente."
							);
							Console.WriteLine ($"ID: {product.Id}");
							Console.WriteLine (
								$"Categoría: {categorySelected.Name}"
							);
							Console.WriteLine (
								$"Proveedor: {supplierSelected.Name}"
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
							Category category =
								new Category (name, description);

							categoryService.AddCategory (category);

							Console.WriteLine ();
							Console.WriteLine (
								"Categoría agregada correctamente."
							);
							Console.WriteLine (
								$"ID generado: {category.Id}"
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
					// AGREGAR PROVEEDOR
					// =========================================
					case 3:
					{
						Console.Clear ();

						Console.WriteLine ("=== AGREGAR PROVEEDOR ===");
						Console.WriteLine ();

						Console.Write ("Nombre: ");
						string name = Console.ReadLine ();

						Console.Write ("Teléfono: ");
						string phone = Console.ReadLine ();

						try
						{
							Supplier supplier =
								new Supplier (name, phone);

							supplierService.AddSupplier (supplier);

							Console.WriteLine ();
							Console.WriteLine (
								"Proveedor agregado correctamente."
							);
							Console.WriteLine (
								$"ID generado: {supplier.Id}"
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
					// LISTAR PRODUCTOS
					// =========================================
					case 4:
					{
						Console.Clear ();

						Console.WriteLine ("=== LISTADO DE PRODUCTOS ===");
						Console.WriteLine ();

						IEnumerable<Product> products =
							productService.GetProducts ();

						if (!products.Any ())
						{
							Console.WriteLine (
								"No hay productos registrados."
							);
							break;
						}

						foreach (Product product in products)
						{
							Category? category =
								categoryService.GetById (
									product.CategoryId
								);

							Supplier? supplier =
								supplierService.GetById (
									product.SupplierId
								);

							string categoryName =
								category?.Name ??
								"Categoría no encontrada";

							string supplierName =
								supplier?.Name ??
								"Proveedor no encontrado";

							Console.WriteLine (
								$"ID: {product.Id} | " +
								$"Nombre: {product.Name} | " +
								$"SKU: {product.Sku} | " +
								$"Precio: ${product.Price} | " +
								$"Stock: {product.Stock}"
							);

							Console.WriteLine (
								$"   Categoría: {categoryName} " +
								$"(ID: {product.CategoryId})"
							);

							Console.WriteLine (
								$"   Proveedor: {supplierName} " +
								$"(ID: {product.SupplierId})"
							);

							Console.WriteLine ();
						}

						break;
					}

					// =========================================
					// LISTAR CATEGORÍAS
					// =========================================
					case 5:
					{
						Console.Clear ();

						Console.WriteLine ("=== LISTADO DE CATEGORÍAS ===");
						Console.WriteLine ();

						IEnumerable<Category> categories =
							categoryService.GetCategories ();

						if (!categories.Any ())
						{
							Console.WriteLine (
								"No hay categorías registradas."
							);
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
					// LISTAR PROVEEDORES
					// =========================================
					case 6:
					{
						Console.Clear ();

						Console.WriteLine ("=== LISTADO DE PROVEEDORES ===");
						Console.WriteLine ();

						IEnumerable<Supplier> suppliers =
							supplierService.GetSuppliers ();

						if (!suppliers.Any ())
						{
							Console.WriteLine (
								"No hay proveedores registrados."
							);
							break;
						}

						foreach (Supplier supplier in suppliers)
						{
							Console.WriteLine (
								$"ID: {supplier.Id} | " +
								$"Nombre: {supplier.Name} | " +
								$"Teléfono: {supplier.Phone} | " +
								$"Activo: {supplier.IsActive}"
							);
						}

						break;
					}

					// =========================================
					// AGREGAR STOCK
					// =========================================
					case 7:
					{
						Console.Clear ();

						Console.WriteLine ("=== AGREGAR STOCK ===");
						Console.WriteLine ();

						Console.Write ("ID de producto: ");

						if (!int.TryParse (
							Console.ReadLine (),
							out int productId))
						{
							Console.WriteLine ("ID inválido.");
							break;
						}

						Product? product =
							productService.GetById (productId);

						if (product == null)
						{
							Console.WriteLine (
								"No existe un producto con ese ID."
							);
							break;
						}

						Console.Write ("Cantidad a agregar: ");

						if (!int.TryParse (
							Console.ReadLine (),
							out int quantity))
						{
							Console.WriteLine ("Cantidad inválida.");
							break;
						}

						try
						{
							productService.UpdateStock (
								productId,
								quantity
							);

							Console.WriteLine ();
							Console.WriteLine (
								"Stock agregado correctamente."
							);
							Console.WriteLine (
								$"Stock actual: {product.Stock}"
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
					// REMOVER STOCK
					// =========================================
					case 8:
					{
						Console.Clear ();

						Console.WriteLine ("=== REMOVER STOCK ===");
						Console.WriteLine ();

						Console.Write ("ID de producto: ");

						if (!int.TryParse (
							Console.ReadLine (),
							out int productId))
						{
							Console.WriteLine ("ID inválido.");
							break;
						}

						Product? product =
							productService.GetById (productId);

						if (product == null)
						{
							Console.WriteLine (
								"No existe un producto con ese ID."
							);
							break;
						}

						Console.Write ("Cantidad a remover: ");

						if (!int.TryParse (
							Console.ReadLine (),
							out int quantity))
						{
							Console.WriteLine ("Cantidad inválida.");
							break;
						}

						try
						{
							productService.UpdateStock (
								productId,
								-quantity
							);

							Console.WriteLine ();
							Console.WriteLine (
								"Stock removido correctamente."
							);
							Console.WriteLine (
								$"Stock actual: {product.Stock}"
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
					// VER MOVIMIENTOS
					// =========================================
					case 9:
					{
						Console.Clear ();

						Console.WriteLine ("=== MOVIMIENTOS DE STOCK ===");
						Console.WriteLine ();

						IEnumerable<StockMovement> movements =
							stockMovementService.GetMovements ();

						if (!movements.Any ())
						{
							Console.WriteLine (
								"No hay movimientos registrados."
							);
							break;
						}

						foreach (StockMovement movement in movements)
						{
							Product? product =
								productService.GetById (
									movement.ProductId
								);

							string productName =
								product?.Name ??
								"Producto no encontrado";

							Console.WriteLine (
								$"ID: {movement.Id} | " +
								$"Producto: {productName} " +
								$"(ID: {movement.ProductId}) | " +
								$"Cantidad: {movement.Quantity} | " +
								$"Tipo: {movement.Type} | " +
								$"Fecha: {movement.CreatedAt}"
							);
						}

						break;
					}

					// =========================================
					// SALIR
					// =========================================
					case 10:
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

				if (opcion != 10)
				{
					Console.WriteLine ();
					Console.WriteLine (
						"Presioná ENTER para continuar..."
					);
					Console.ReadLine ();
				}
			}
		}
	}
}