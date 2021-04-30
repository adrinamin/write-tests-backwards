using System;
using System.Reflection;
using System.Runtime.CompilerServices;

using Autofac;

using Microsoft.Extensions.Logging;

using RoboFriend.ConsoleApp;

namespace RoboFriend.Core
{
    internal class Program
    {
        private const string RoboFriendInfrastructureAssembly = "RoboFriend.Infrastructure.dll";
        private const string RoboFriendConsoleAppAssembly = "RoboFriend.ConsoleApp.dll";
        private static IContainer container;


        internal static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.LoadFrom(RoboFriendInfrastructureAssembly));
            builder.RegisterAssemblyTypes(Assembly.LoadFrom(RoboFriendConsoleAppAssembly));
            builder.RegisterType<WelcomeMessageCreator>().As<IWelcomeMessageCreator>();
            builder.RegisterType<AppStarter>().As<IAppStarter>();
            container = builder.Build();

            StartApp();

            Console.ReadKey();
        }

        private static void StartApp()
        {
            using var scope = container.BeginLifetimeScope();
            var appStarter = scope.Resolve<IAppStarter>();
            appStarter.RunApp();
        }
    }
}
