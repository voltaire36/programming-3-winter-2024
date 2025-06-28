using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DataAccessLibrary
{
    public class OmsContextFactory : IDesignTimeDbContextFactory<OmsContext>
    {
        public OmsContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("OmsDatabase")
                               ?? throw new InvalidOperationException("Connection string 'OmsDatabase' not found.");

            var builder = new DbContextOptionsBuilder<OmsContext>();
            builder.UseSqlServer(connectionString);

            return new OmsContext(builder.Options);
        }
    }
}
