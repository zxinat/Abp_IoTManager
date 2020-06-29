using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace IoT.Application.GatewayAppService.DTO
{
    public class GatewayTypeDto:EntityDto<int>
    {
        public string TypeId { get; set; }
        public string TypeName { get; set; }
        public decimal OfflineTime { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }

    }
}
