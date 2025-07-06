using Microsoft.EntityFrameworkCore;

namespace Lab6.Models;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	public DbSet<User> Users { get; set; }
	public DbSet<Fruit> Fruits { get; set; }
}
