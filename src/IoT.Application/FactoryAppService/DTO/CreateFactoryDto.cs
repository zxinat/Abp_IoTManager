using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace IoT.Application.FactoryAppService.DTO
{
    public class CreateFactoryDto:EntityDto<int>
    {
        public string CityName { get; set; }
        public string FactoryName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
    }
}
