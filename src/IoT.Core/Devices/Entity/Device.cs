using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace IoT.Core
{
    [Table(IoTConsts.TablePrefix + "Device")]
    public class Device:Entity<int>,IFullAudited
    {
        public Device()
        {
            CreationTime = DateTime.Now;
            LastModificationTime = DateTime.Now;
            DeletionTime = DateTime.Now;
        }

        [Required]
        [MaxLength(100)]
        public string HardwareId { get; set; }
        [Required]
        [MaxLength(100)]
        public string DeviceName { get; set; }
        [ForeignKey("GatewayId")]
        public int GatewayId { get; set; }
        public Gateway Gateway { get; set; }
        [MaxLength(100)]
        public string ImageUrl { get; set; }
        [MaxLength(50)]
        public string Mac { get; set; }
        [ForeignKey("DeviceTypeId")]
        public int DeviceTypeId { get; set; }
        public DeviceType DeviceType { get; set; }
        [MaxLength(255)]
        public string Remark { get; set; }
        public DateTime LastConnectionTime { get; set; }
        [MaxLength(100)]
        public string PictureRoute { get; set; }
        [Column(TypeName = "mediumtext")]
        public string Base64Image { get; set; }
        public byte IsOnline { get; set; }

        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }

        internal void SetOn()
        {
            IsOnline = 1;
        }

        internal void SetOff()
        {
            IsOnline = 0;
            LastConnectionTime=DateTime.Now;
        }
    }
}
