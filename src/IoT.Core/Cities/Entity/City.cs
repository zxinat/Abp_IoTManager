using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace IoT.Core
{
    [Table(IoTConsts.TablePrefix + "City")]
    public class City:Entity<int>,IFullAudited
    {
        public City()
        {
            CreationTime = DateTime.Now;
        }
        [Required]
        [MaxLength(30)]
        public string CityName { get; set; }
        [Required]
        [MaxLength(30)]
        public string CityCode { get; set; }
        [MaxLength(255)]
        public string Remark { get; set; }
        [Column(TypeName = "decimal(11,2)")]
        public decimal? Longitude { get; set; }
        [Column(TypeName = "decimal(11,2)")]
        public decimal? Latitude { get; set; }
        private List<Factory> Factories { get; set; }

        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
    }
}
