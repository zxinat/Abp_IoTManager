using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace IoT.Core
{
    [Table(IoTConsts.TablePrefix + "Workshop")]
    public class Workshop:Entity<int>,IFullAudited
    {
        public Workshop()
        {
            CreationTime = DateTime.Now;
            LastModificationTime = DateTime.Now;
        }

        [Required]
        [MaxLength(30)]
        public string WorkshopName { get; set; }
        [MaxLength(30)]
        public string PhoneNumber { get; set; }
        [MaxLength(100)] 
        public string Address { get; set; }
        [MaxLength(255)]
        public string Remark { get; set; }
        public int FactoryId { get; set; }
        [ForeignKey("FactoryId")]
        public Factory Factory { get; set; }

        private List<Gateway> Gateways { get; set; }

        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
    }
}
