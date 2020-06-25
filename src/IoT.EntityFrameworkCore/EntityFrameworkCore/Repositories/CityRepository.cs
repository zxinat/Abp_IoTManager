using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.EntityFrameworkCore;
using IoT.Core;
using IoT.Core.Cities;
using Microsoft.AspNetCore.Http;

namespace IoT.EntityFrameworkCore.Repositories
{
    public class CityRepository:IoTRepositoryBase<City,int>,ICityRepository
    {
        public CityRepository(IDbContextProvider<IoTDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public City Create(City entity)
        {
            var cities = GetAll().Where(c => c.CityName == entity.CityName || c.CityCode == entity.CityCode);
            if (!cities.Any())
            {
                return Insert(entity);
            }
            else
            {
                throw new ApplicationException($"城市：{entity.CityName} 已存在！");
            }

            
        }
    }
}
