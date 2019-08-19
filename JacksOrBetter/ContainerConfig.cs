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
            builder.RegisterType<Library.Utilities.Card>().As<Library.Utilities.ICard>();
            builder.RegisterType<Library.Utilities.Deck>().As<Library.Utilities.IDeck>();

            return builder.Build();
        }
    }
}
