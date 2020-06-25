using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace IoT.Core
{
    [Table(IoTConsts.TablePrefix + "Severity")]
    public class Severity:Entity<int>,IAudited
    {
        [Required]
        [MaxLength(50)]
        public string SeverityName { get; set; }
        public Severity()
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
