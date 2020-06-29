using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using IoT.Core;

namespace IoT.Application.FactoryAppService.DTO
{
    public class FactoryDto:EntityDto<int>
    {
        public string CityName { get; set; }
        public string FactoryName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastModificationTime { get; set; }
    }
}
