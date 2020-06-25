using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Dependency;

namespace IoT.Core.MongoDb
{
    public interface IDeviceDataManager
    {
        DeviceData GetByName(string deviceName);
        List<DeviceData> GetAll(PagedResultRequestDto input);
    }
}
