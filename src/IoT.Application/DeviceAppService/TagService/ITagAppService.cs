using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using L._52ABP.Application.Dtos;

namespace IoT.Application.DeviceAppService
{
    public interface ITagAppService:ICrudAppService<TagDto,int,PagedSortedAndFilteredInputDto,CreateTagDto>
    {
    }
}
