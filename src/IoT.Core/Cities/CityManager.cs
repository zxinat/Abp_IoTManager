using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

namespace IoT.Core.Cities
{
    public class CityManager:DomainService,ICityManager
    {
        private readonly ICityRepository _cityRepositories;
        public CityManager(ICityRepository cityRepositories)
        {
            _cityRepositories = cityRepositories;
        }

        public void Delete(City entity)
        {
            _cityRepositories.Delete(entity);
        }

        public City Update(City entity)
        {
           return _cityRepositories.Update(entity);
        }

    }
}
