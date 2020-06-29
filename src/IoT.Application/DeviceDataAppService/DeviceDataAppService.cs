using Abp.Application.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Uow;
using AutoMapper;
using IoT.Core;
using IoT.Core.MongoDb;

namespace IoT.Application
{
    public class DeviceDataAppService : ApplicationService
    {
        //private readonly IDeviceDataRepository _dataRepository;
        private readonly IDeviceDataManager _dataManager;

        public DeviceDataAppService( IDeviceDataManager dataManager)
        {
           // _dataRepository = dataRepository;
            _dataManager = dataManager;
        }


        public PagedResultDto<DeviceDataDto> GetAll(PagedResultRequestDto input)
        {
            
            var data= _dataManager.GetAll(input);
            var total = data.Count;
            
  
            return new PagedResultDto<DeviceDataDto>(total,ObjectMapper.Map<List<DeviceDataDto>>(data));
        }

        public DeviceDataDto GetByName(string deviceName)
        {
            var data = _dataManager.GetByName(deviceName);
            return ObjectMapper.Map<DeviceDataDto>(data);
        }
    }
}
