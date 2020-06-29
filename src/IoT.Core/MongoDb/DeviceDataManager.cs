using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using MongoDB.Driver;
using System.Linq;
using Abp.Domain.Services;
using Microsoft.Extensions.Options;
using IoTManager;
using Microsoft.Extensions.Options;

namespace IoT.Core.MongoDb
{
    public class DeviceDataManager:DomainService,IDeviceDataManager
    {
        
        //private readonly MongoDbConfiguration _mongoConfiguration;
        private readonly IMongoCollection<DeviceData> _deviceDatas;
        private readonly IOptions<ConnectionStrings> _connectionStrings;

        public DeviceDataManager(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings;
            //var mongoConfiguration = new MongoDbConfiguration();
            
            var client = new MongoClient(_connectionStrings.Value.MongoDb);
            
            var database = client.GetDatabase(MongoConsts.DbName);
            _deviceDatas = database.GetCollection<DeviceData>(MongoConsts.MonitorData);
            
        }

        public DeviceData GetByName(string deviceName)
        {
            var result= _deviceDatas.FindAsync(d => d.DeviceName == deviceName).Result.FirstOrDefault(); 
            return result;

        }

        public List<DeviceData> GetAll(PagedResultRequestDto input)
        {
            
            var query = _deviceDatas.AsQueryable();
            int total = query.Count();
            var result = query.OrderBy(dd => dd.Timestamp).Skip(input.SkipCount).Take(input.MaxResultCount).ToList();
            return result;
            
        }
    }
}
