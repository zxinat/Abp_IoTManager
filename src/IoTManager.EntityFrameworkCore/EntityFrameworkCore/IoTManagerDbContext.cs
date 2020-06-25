using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using IoTManager.Authorization.Roles;
using IoTManager.Authorization.Users;
using IoTManager.MultiTenancy;

namespace IoTManager.EntityFrameworkCore
{
    public class IoTManagerDbContext : AbpZeroDbContext<Tenant, Role, User, IoTManagerDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public IoTManagerDbContext(DbContextOptions<IoTManagerDbContext> options)
            : base(options)
        {
        }
    }
}
