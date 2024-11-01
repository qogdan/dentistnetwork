using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
    public RepositoryContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        //migrations assembly is not in main project, but in the Repository project, 
        var builder = new DbContextOptionsBuilder<RepositoryContext>()
            .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
            b => b.MigrationsAssembly("DentistNetwork"));

        return new RepositoryContext(builder.Options);
    }
}
