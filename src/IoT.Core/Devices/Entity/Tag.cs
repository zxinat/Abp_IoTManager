using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace IoT.Core
{
    [Table(IoTConsts.TablePrefix + "Tag")]
    public class Tag:Entity<int>,IAudited
    {
        [Required]
        [MaxLength(50)]
        public string TagName { get; set; }
        public Tag()
        {
            CreationTime = DateTime.Now;
            LastModificationTime = DateTime.Now;
        }

        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
    }
}
