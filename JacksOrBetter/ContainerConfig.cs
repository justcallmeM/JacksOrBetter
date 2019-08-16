using Autofac;
using Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace JacksOrBetter
{
    class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();

            return builder.Build();
        }
    }
}
