using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using IoT.Core;

namespace IoT.Application.CityAppService.DTO
{
    [AutoMapFrom(typeof(City))]
    public class CityDto:EntityDto<int>
    {
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
