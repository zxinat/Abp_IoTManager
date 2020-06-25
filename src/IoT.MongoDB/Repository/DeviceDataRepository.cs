using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.MongoDb;
using Abp.MongoDb.Repositories;
using IoT.Application;
using MongoDB.Driver;
using Abp.AutoMapper;
using AutoMapper;
using IoT.Core;

namespace IoT.MongoDB.Repository
{
    public class DeviceDataRepository:ITransientDependency
    {
        private IMongoCollection<DeviceData> _deviceDatas;
        private IMongoClient _client;
        private IMongoDatabase _database;

        public DeviceDataRepository()
        {
            _client=new MongoClient("mongodb://iotmanager:iotmanager-pwd@118.31.2.239:27017/?authSource=iotmanager");
            _database = _client.GetDatabase("iotmanager");
            _deviceDatas = _database.GetCollection<DeviceData>("monitordata");
        }

        public PagedResultDto<DeviceData> GetAll(PagedResultRequestDto input)
        {
            var query = _deviceDatas.AsQueryable()
                .Where(dd => dd.DeviceId == "Pangu001")
                .OrderBy(dd => dd.Timestamp)
                .Take(input.MaxResultCount)
                .ToList();
            return new PagedResultDto<DeviceData>(query.Count,query);
        }
    }
}
