using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace IoT.Application.DeviceAppService
{
    public class CreateTagDto:EntityDto<int>
    {
        public string TagName { get; set; }
    }
}
