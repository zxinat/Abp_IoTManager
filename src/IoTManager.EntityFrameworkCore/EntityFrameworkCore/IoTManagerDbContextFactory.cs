using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using IoTManager.Configuration;
using IoTManager.Web;

namespace IoTManager.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class IoTManagerDbContextFactory : IDesignTimeDbContextFactory<IoTManagerDbContext>
    {
        public IoTManagerDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<IoTManagerDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            IoTManagerDbContextConfigurer.Configure(builder, configuration.GetConnectionString(IoTManagerConsts.ConnectionStringName));

            return new IoTManagerDbContext(builder.Options);
        }
    }
}
