using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using MongoDB.Driver;
using System.Linq;

namespace IoT.Core.MongoDb
{
    public class DeviceDataManager:ITransientDependency,IDeviceDataManager
    {
        private readonly MongoDbConfiguration _mongoConfiguration;
        private readonly IMongoCollection<DeviceData> _deviceDatas;
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public DeviceDataManager()
        {
            _mongoConfiguration = new MongoDbConfiguration();
            _client = new MongoClient(_mongoConfiguration.ConnectionStr);
            _database = _client.GetDatabase(MongoConsts.DbName);
            _deviceDatas = _database.GetCollection<DeviceData>(MongoConsts.MonitorData);
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
