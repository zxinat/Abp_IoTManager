using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using IoT.Core.Thresholds;
using NPOI.HSSF.Record;

namespace IoT.Core
{
    [Table(IoTConsts.TablePrefix + "Threshold")]
    public class Threshold:Entity<int>,IFullAudited
    {
        [Required]
        [MaxLength(100)]
        public string RuleName { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public int FieldId { get; set; }
        [ForeignKey("FieldId")]
        public Field Field { get; set; }
        [Required]
        public string Operator { get; set; }
        [Column(TypeName = "decimal(11,2)")]
        public decimal ThresholdValue { get; set; }
        public int SeverityId { get; set; }
        [ForeignKey("SeverityId")]
        public Severity Severity { get; set; }

        public Threshold()
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
