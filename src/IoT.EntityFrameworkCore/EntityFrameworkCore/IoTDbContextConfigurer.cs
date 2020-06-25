using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace IoT.EntityFrameworkCore
{
    public static class IoTDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<IoTDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<IoTDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
