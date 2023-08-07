using Application.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace Infrastructure.Context
{

    public class AnimalShelterDbContextFactory : IDesignTimeDbContextFactory<AnimalShelterDbContext>
    {
        private IConfiguration configuration;
        public AnimalShelterDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AnimalShelterDbContext>();

            var folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Path.Combine(folderPath, "sharedsettings.json"), false, true)
                .AddEnvironmentVariables()
                .Build();
            AppUtilities.AppUtilitiesConfigure(configuration);

            optionsBuilder.UseSqlServer(GetDbConnectionText());
            return new AnimalShelterDbContext(optionsBuilder.Options);
        }

        private static string GetDbConnectionText()
        {
            string connectionString = AppUtilities.GetConfigurationValue("DBConnectionText");
            return connectionString;
        }
    }
}
