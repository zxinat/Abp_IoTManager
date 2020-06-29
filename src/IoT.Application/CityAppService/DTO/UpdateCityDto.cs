using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using IoT.Core;

namespace IoT.Application.CityAppService.DTO
{
    public class UpdateCityDto:EntityDto
    {
        public string Remark { get; set; }
    }
}
