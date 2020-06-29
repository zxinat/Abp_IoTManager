using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;

namespace IoT.Application.GatewayAppService.DTO
{
    public class GatewayDto:EntityDto<int>
    {
        public string CityName { get; set; }
        public string FactoryName { get; set; }
        public string WorkshopName { get; set; }
        public string HardwareId { get; set; }
        public string GatewayName { get; set; }
        public string GatewayTypeName { get; set; }
        public string Remark { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}
