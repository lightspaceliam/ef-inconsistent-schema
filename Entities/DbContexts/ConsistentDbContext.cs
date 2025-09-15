using Microsoft.EntityFrameworkCore;

namespace Entities.DbContexts;

public class ConsistentDbContext : DbContext
{
	public ConsistentDbContext(DbContextOptions<ConsistentDbContext> options)
		: base (options) { }

	public ConsistentDbContext()
	{ }

	public DbSet<Organisation> Organisations { get; set; }
	public DbSet<Patient> Patients { get; set; }
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		/*  Alternatively, you could replace all the data annotations
		 *  on individual entities and configure them here.
		 *  The Fluent API provides greater access to features that are not
		 *  yet available to Data Annotations however, when you have a large
		 *  quantity of tables, this file will grow quickly and readability will suffer. 
		 */
		base.OnModelCreating(modelBuilder);
	}
}