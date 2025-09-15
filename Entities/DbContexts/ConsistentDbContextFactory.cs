using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Entities.DbContexts;

public class ConsistentDbContextFactory : IDesignTimeDbContextFactory<ConsistentDbContext>
{
	public ConsistentDbContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<ConsistentDbContext>();
		//  Windows.
		// optionsBuilder.UseSqlServer("Server=localhost;Database=ConsistentDbContext;Integrated Security=True;MultipleActiveResultSets=True");
            
		//  Docker - you will need to add, name and set your own: container and credentials.
		optionsBuilder.UseSqlServer("Server=tcp:localhost,1433;Initial Catalog=ConsistentDbContext;Persist Security Info=False;User ID=SA;Password=Local@DevPa55word;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

		return new ConsistentDbContext(optionsBuilder.Options);
	}
}