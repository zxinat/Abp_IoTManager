using System;
using System.Collections.Generic;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using IoT.Core.MongoDb;

namespace IoT.Core
{
    public class CustomDI:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.From().BasedOn<IDeviceDataManager>().LifestylePerThread()
                .WithServiceSelf());
        }
    }
}
