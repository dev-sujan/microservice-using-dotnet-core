using MongoRepo.Context;

namespace Catalog.API.Context
{
    public class CatalogDBContext : ApplicationDbContext
    {
        private static readonly IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true).Build();

        private static readonly string connectionString = configuration.GetConnectionString("Catalog.API");
        private static readonly string databaseName = configuration.GetValue<string>("DatabaseName");

        public CatalogDBContext() : base(connectionString, databaseName)
        {
        }

    }
}
