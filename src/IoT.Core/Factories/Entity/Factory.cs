using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IoT.Core
{
    [Table(IoTConsts.TablePrefix + "Factory")]
    public class Factory:Entity<int>,IFullAudited
    {
        public Factory()
        {
            CreationTime = DateTime.Now;
            LastModificationTime=DateTime.Now;
        }

        /// <summary>
        /// 工厂/实验楼名称
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string FactoryName { get; set; }
        [MaxLength(30)]
        public string PhoneNumber { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(255)]
        public string Remark { get; set; }
        [MaxLength(11)]
        public int CityId { get; set; }
        /// <summary>
        /// 所属城市
        /// </summary>
        [ForeignKey("CityId")]
        public City City { get; set; }

        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
    }
}
