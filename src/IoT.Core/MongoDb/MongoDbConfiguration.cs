using System;
using System.Collections.Generic;
using System.Text;
using IoT.Core.Configuration;
using IoT.Core.Web;
using Microsoft.Extensions.Configuration;

namespace IoT.Core.MongoDb
{
    public class MongoDbConfiguration
    {
        public string ConnectionStr;

        public MongoDbConfiguration()
        {
             var  configuration= AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
             ConnectionStr = configuration.GetConnectionString(MongoConsts.StrName);
        }

    }
}
