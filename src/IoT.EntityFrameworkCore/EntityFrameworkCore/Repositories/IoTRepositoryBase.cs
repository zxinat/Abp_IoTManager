using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace IoT.EntityFrameworkCore.Repositories
{
    public class IoTRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<IoTDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public IoTRepositoryBase(IDbContextProvider<IoTDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
