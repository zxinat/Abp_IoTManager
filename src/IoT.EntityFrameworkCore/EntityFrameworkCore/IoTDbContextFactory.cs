using System;
using System.Collections.Generic;
using System.Text;
using IoTManager.Configuration;
using IoT.Core;
using IoT.Core.Web;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace IoT.EntityFrameworkCore
{
    public class IoTDbContextFactory: IDesignTimeDbContextFactory<IoTDbContext>
    {
        public IoTDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<IoTDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            IoTDbContextConfigurer.Configure(builder, configuration.GetConnectionString(IoTConsts.ConnectionStringName));

            return new IoTDbContext(builder.Options);
        }
    }
}
