using InventoryManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Infrastructure.Data
{
	public class InventoryContext : DbContext
	{
		public InventoryContext (DbContextOptions<InventoryContext> options) : base (options)
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<StockMovement> StockMovements { get; set; }

		protected override void OnModelCreating (ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product> ()
				.HasOne<Category> ()
				.WithMany ()
				.HasForeignKey (p => p.CategoryId);

			modelBuilder.Entity<Product> ()
				.HasOne<Supplier> ()
				.WithMany ()
				.HasForeignKey (p => p.SupplierId);

			modelBuilder.Entity<StockMovement> ()
				.HasOne<Product> ()
				.WithMany ()
				.HasForeignKey (sm => sm.ProductId);
		}
	}
}