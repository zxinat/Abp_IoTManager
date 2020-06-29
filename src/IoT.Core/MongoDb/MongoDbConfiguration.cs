using System;
using System.Collections.Generic;
using System.Text;
using IoTManager.Configuration;
using IoT.Core.Web;
using IoTManager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver.Core.Configuration;

namespace IoT.Core.MongoDb
{
    public class MongoDbConfiguration
    {
        public string ConnectionStr;
        private readonly IOptions<ConnectionStrings> _connectionStrings;
        public MongoDbConfiguration(IOptions<ConnectionStrings> connectionStrings)
        {
            //var  configuration= AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
            //ConnectionStr = configuration.GetConnectionString(MongoConsts.StrName);
            //ConnectionStr = "mongodb://iotmanager:iotmanager-pwd@118.31.2.239:27017/?authSource=iotmanager";
            ConnectionStr = _connectionStrings.Value.MongoDb;
        }

    }
}
