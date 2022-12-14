using Microsoft.EntityFrameworkCore;
using RS_API.Entities;

namespace RS_API;

public class StoreDbContext : DbContext
{
	private readonly IConfiguration _configuration;

	public StoreDbContext(IConfiguration configuration)
	{
		_configuration = configuration;
	}
	
	public DbSet<Record> Records { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<OrderRecord> OrderRecords { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Order-Record relationship
		modelBuilder.Entity<OrderRecord>()
			.HasKey(x => new { x.OrderId, x.RecordId });

		modelBuilder.Entity<OrderRecord>()
			.HasOne(x => x.Order)
			.WithMany(x => x.OrderRecords)
			.HasForeignKey(x => x.OrderId);

		modelBuilder.Entity<OrderRecord>()
			.HasOne(x => x.Record)
			.WithMany()
			.HasForeignKey(x => x.RecordId);

		modelBuilder.Entity<Order>()
			.HasMany(x => x.OrderRecords)
			.WithOne(x => x.Order)
			.HasForeignKey(x => x.OrderId);
	}


	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		// Connect to sqlite database
		options.UseSqlite(_configuration.GetConnectionString("DbConnection"));
	}
}