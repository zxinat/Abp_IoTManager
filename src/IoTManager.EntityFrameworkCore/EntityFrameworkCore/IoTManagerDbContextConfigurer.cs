using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace IoTManager.EntityFrameworkCore
{
    public static class IoTManagerDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<IoTManagerDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<IoTManagerDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
