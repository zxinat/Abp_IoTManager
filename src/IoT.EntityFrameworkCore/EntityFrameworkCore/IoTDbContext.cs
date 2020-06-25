using System;
using System.Collections.Generic;
using System.Text;
using Abp.EntityFrameworkCore;
using IoT.Core;
using Microsoft.EntityFrameworkCore;

namespace IoT.EntityFrameworkCore
{
    public class IoTDbContext: AbpDbContext
    {
        /*定义专属IoT的实体 DBSet*/
        public IoTDbContext(DbContextOptions<IoTDbContext> options):base(options)
        {
        }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Factory> Factory { get; set; }
        public virtual DbSet<Workshop> Workshop { get; set; }
        public virtual DbSet<Gateway> Gateway { get; set; }
        public virtual DbSet<GatewayType> GatewayType { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<DeviceType> DeviceType { get; set; }
        public virtual DbSet<DeviceTag> DeviceTag { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<OnlineTimeDaily> OnlineTimeDaily { get; set; }
        public virtual DbSet<Field> Field { get; set; }
        public virtual DbSet<Threshold> Threshold { get; set; }
        public virtual DbSet<Severity> Severity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
