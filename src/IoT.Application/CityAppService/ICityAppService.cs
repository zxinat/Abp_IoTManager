using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Services;
using IoT.Application.CityAppService.DTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IoT.Application.CityAppService
{
    public interface ICityAppService:ICrudAppService<CityDto,int,CityPagedSortedAndFilteredDto,CreateCityDto,UpdateCityDto>
    {
    }
}
