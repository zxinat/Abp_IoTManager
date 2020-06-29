using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace IoT.Application.DeviceAppService
{
    public class TagDto:EntityDto<int>
    {
        public string TagName { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
