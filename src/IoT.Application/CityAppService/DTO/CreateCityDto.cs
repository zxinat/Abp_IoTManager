using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using IoT.Core;

namespace IoT.Application.CityAppService.DTO
{
    [AutoMapTo(typeof(City))]
    public class CreateCityDto:EntityDto<int>
    {
        [Required]
        public string CityName { get; set; }

        public string Remark { get; set; }
    }
}
