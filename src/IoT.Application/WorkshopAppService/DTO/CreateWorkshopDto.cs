using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace IoT.Application.WorkshopAppService.DTO
{
    public class CreateWorkshopDto: EntityDto<int>
    {

        public string WorkshopName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public string CityName { get; set; }
        public string FactoryName { get; set; }
    }
}
