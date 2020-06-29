using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using IoT.Application.WorkshopAppService.DTO;
using L._52ABP.Application.Dtos;

namespace IoT.Application.WorkshopAppService
{
    public interface IWorkshopAppService:ICrudAppService<WorkshopDto,int,PagedSortedAndFilteredInputDto,CreateWorkshopDto>
    {
    }
}
