using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace IoT.Core
{
    [Table(IoTConsts.TablePrefix + "Gateway")]
    public class Gateway:Entity<int>,IFullAudited
    {
        public Gateway()
        {
            CreationTime = DateTime.Now;
            LastModificationTime = DateTime.Now;
        }

        [Required]
        [MaxLength(50)]
        public string HardwareId { get; set; }
        [Required]
        [MaxLength(50)]
        public string GatewayName { get; set; }
        public int GatewayTypeId { get; set; }
        [ForeignKey("GatewayTypeId")]
        public GatewayType GatewayType { get; set; }

        public int WorkshopId { get; set; }
        [ForeignKey("WorkshopId")]

        public Workshop Workshop { get; set; }
        [MaxLength(255)]
        public string Remark { get; set; }
        [MaxLength(100)]
        public string ImageUrl { get; set; }
        public DateTime LastConnectionTime { get; set; }
        public byte IsOnline { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
    }
}
