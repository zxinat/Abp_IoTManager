using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
namespace IoT.Core.Cities
{
    public interface ICityRepository:IRepository<City,int>
    {
        City Create(City entity);
    }
}
