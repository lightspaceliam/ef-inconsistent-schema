// See https://aka.ms/new-console-template for more information

using Entities;
using Entities.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddUserSecrets<Program>();

        var environment = context.HostingEnvironment;
        Console.WriteLine($"Environment: {environment.EnvironmentName}");

    })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddLogging();
        
        var connectionString = hostContext.Configuration["ConnectionStrings:Connection"] ?? throw new ArgumentNullException("ConnectionStrings:Connection");

        services.AddDbContext<ConsistentDbContext>(options =>
        {
            options.UseSqlServer(
                connectionString,
                optionsBuilder =>
                {
                    optionsBuilder.ExecutionStrategy(
                        context => new SqlServerRetryingExecutionStrategy(context, 10, TimeSpan.FromMilliseconds(200), null));
                });
        });

        
    })
    .Build();

using var scope = host.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ConsistentDbContext>();

//  Seed data.
var organisations = new List<Organisation>
{
    new Organisation { Name = "The Empire" },
    new Organisation { Name = "Rebels" }
};
var patients = new List<Patient>
{
    new Patient { FirstName = "Luke" },
    new Patient { FirstName = "Han" },
    new Patient { FirstName = "Ben" }
};

context.Organisations.AddRange(organisations);
context.Patients.AddRange(patients);
await context.SaveChangesAsync();

var luke = await context.Patients
    .FirstOrDefaultAsync(p => p.FirstName == "Luke");

if (luke == null)
{
    Console.WriteLine("Patient not found");
}
else
{
    Console.WriteLine($"Patient found - Id: {luke.Id}, FirstName: {luke.FirstName}");
}

var empire = await context.Organisations
    .FirstOrDefaultAsync(p => p.Name == "The Empire");

if (empire == null)
{
    Console.WriteLine("Organisation not found");
}else
{
    Console.WriteLine($"Organisation found - Id: {empire.Id}, Name: {empire.Name}");
}

Console.WriteLine("Hello, Inconsistent Schema!");