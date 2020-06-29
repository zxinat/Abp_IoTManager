using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace IoT.Core
{
    [Table(IoTConsts.TablePrefix + "GatewayType")]
    public class GatewayType:Entity<int>,IAudited
    {
        public GatewayType()
        {
            CreationTime = DateTime.Now;
            LastModificationTime = DateTime.Now;
            OfflineTime = 30;
        }
        [Required]
        [MaxLength(50)]
        public string TypeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string TypeName { get; set; }
        [Column(TypeName = "decimal(11,2)")]
        public decimal OfflineTime { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
    }
}
