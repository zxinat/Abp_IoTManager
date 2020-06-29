using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Services;

namespace IoT.Core.MongoDb
{
    public interface IDeviceDataManager:IDomainService
    {
        DeviceData GetByName(string deviceName);
        List<DeviceData> GetAll(PagedResultRequestDto input);
    }
}
