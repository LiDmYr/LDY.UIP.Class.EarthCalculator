using Autofac;
using LDY.Lesson8.EarthCalculator.BAL.EarthCalculator.Services;
using LDY.Lesson8.EarthCalculator.Shared.Interfaces;
using LDY.Lesson8.EarthCalculator.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.Lesson8.EarthCalculator.Core {
    public class AppContainer {
        private static IContainer _container;

        public static void ConfigureContainer() {
            var builder = new ContainerBuilder();

            //builder.RegisterType<DBWriter>().As<IDBRepository>().SingleInstance();
            builder.RegisterType<FileWriter>().As<IFileWriter>().SingleInstance();
            builder.RegisterType<ConsoleWriter>().As<IConsoleWriter>().SingleInstance();
            builder.RegisterType<PointsValidator>().As<IPointsValidator>();
            builder.RegisterType<BAL.EarthCalculator.Services.EarthCalculator>().As<IEarthCalculator>();
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
            builder.RegisterType<JSONSerializer>().As<IJONSerializer>();


            _container = builder.Build();
        }

        //public static object Resolve(Type typeName) {
        //    return _container.Resolve(typeName);
        //}

        public static T Resolve<T>() {
            return _container.Resolve<T>();
        }
    }
}
