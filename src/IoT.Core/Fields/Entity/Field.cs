using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace IoT.Core
{
    [Table(IoTConsts.TablePrefix + "Field")]
    public class Field:Entity<int>,IFullAudited
    {
        [Required]
        [MaxLength(50)]
        public string FieldName { get; set; }
        [Required]
        [MaxLength(50)]
        public string IndexId { get; set; }
        public int DeviceId { get; set; }
        [ForeignKey("DeviceId")]
        public Device Device { get; set; }

        public Field()
        {
            CreationTime = DateTime.Now;
            LastModificationTime = DateTime.Now;
            DeletionTime = DateTime.Now;
        }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
    }
}
