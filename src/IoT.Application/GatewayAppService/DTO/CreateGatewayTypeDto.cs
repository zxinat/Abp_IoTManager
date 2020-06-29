using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;

namespace IoT.Application.GatewayAppService.DTO
{
    public class CreateGatewayTypeDto:EntityDto<int>
    {
        public string TypeId { get; set; }
        public string TypeName { get; set; }
        public decimal OfflineTime { get; set; }
    }
}
