using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDugga.Service
{
    using Autofac;
    using CrudDugga.Crud;
    using CrudDugga.DisplayFolder;
    using CrudDugga.Interface;
    using CrudDugga.UserFolder;

    public static class DependencyInjection
    {
        public static IContainer Configure()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<Menu>().As<IMenu>();
            containerBuilder.RegisterType<Menu>();

            containerBuilder.RegisterType<UserFileReader>().As<IReadFile<UserFolder.User>>();
            containerBuilder.RegisterType<DisplayNameRight>().As<IDisplay>();
            containerBuilder.RegisterType<UserFileReader>();

            containerBuilder.RegisterType<Create>();
            containerBuilder.RegisterType<Read>();
            containerBuilder.RegisterType<Update>();
            containerBuilder.RegisterType<Delete>();


            return containerBuilder.Build();

        }
    }

}
