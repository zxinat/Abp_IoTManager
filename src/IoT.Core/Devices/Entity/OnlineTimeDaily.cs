using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using NPOI.SS.Formula.Functions;

namespace IoT.Core
{
    [Table(IoTConsts.TablePrefix+"OnlineTimeDaily")]
    public class OnlineTimeDaily:Entity<int>,IAudited
    {
        public int DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public Device Device { get; set; }
        /// <summary>
        /// 设备每日在线时长 单位：min
        /// </summary>
        [Column(TypeName = "decimal(11,2)")]
        public decimal OnlineTime { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime Date { get; set; }
        public OnlineTimeDaily()
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
