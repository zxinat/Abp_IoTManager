using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Services;

namespace IoT.Core.Cities
{
    public interface ICityManager:IDomainService
    {
        void Delete(City entity);
    }
}
