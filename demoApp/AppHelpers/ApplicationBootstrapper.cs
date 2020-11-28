using System;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using demoApp.Interfaces.Logger;
using demoApp.Interfaces.PlatformServices;
using demoApp.Interfaces.VMServices;
using demoApp.Interfaces.WebService;
using demoApp.Services.Logger;
using demoApp.Services.PlatformServices;
using demoApp.Services.VMServices;
using demoApp.Services.WebService;
using demoApp.ViewModels;
using demoApp.Views;

namespace demoApp.AppHelpers
{
    public sealed class ApplicationBootstrapper
    {
        /// <summary>
        /// Creation of IoC Container
        /// </summary>
        public static void Initialize()
        {
            var containerBuilder = new ContainerBuilder();
            RegisterServices(containerBuilder);
        }

        /// <summary>
        /// Register all Contracts and their Implementation
        /// </summary>
        /// <param name="containerBuilder">containerBuilder is a parameter of ContainerBuilder used to build an IContainer from component registration</param>
        private static void RegisterServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
            containerBuilder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            containerBuilder.RegisterType<WebServiceClient>().As<IWebServiceClient>().SingleInstance();
            containerBuilder.RegisterType<LoggingService>().As<ILoggingService>().SingleInstance();
            RegisterViewModelServices(containerBuilder);
            RegisterViewModels(containerBuilder);

        }

        /// <summary>
        /// Register All ViewModel related services
        /// </summary>
        /// <param name="containerBuilder">containerBuilder is a parameter of ContainerBuilder used to build an IContainer from component registration</param>
        private static void RegisterViewModelServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<LoginService>().As<ILoginService>().SingleInstance();

        }

        /// <summary>
        /// Register All ViewModels
        /// </summary>
        /// <param name="containerBuilder">containerBuilder is a parameter of ContainerBuilder used to build an IContainer from component registration</param>
        private static void RegisterViewModels(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<BaseViewModel>().AsSelf().SingleInstance();
            containerBuilder.RegisterType<LoginViewModel>().AsSelf().SingleInstance();
            RegisterViews(containerBuilder);
        }

        /// <summary>
        /// Register All Views
        /// </summary>
        /// <param name="containerBuilder">containerBuilder is a parameter of ContainerBuilder used to build an IContainer from component registration</param>
        private static void RegisterViews(ContainerBuilder containerBuilder)
        {
            var container = containerBuilder.Build();
            var navigationService = container.Resolve<INavigationService>();
            navigationService.Configure(nameof(LoginView), typeof(LoginView));

            BuildServiceContainer(container);
        }

        /// <summary>
        /// Build your Service Container which can be used to resolve Views/Viewmodel/Services whenever required
        /// </summary>
        /// <param name="container">container is a parameter of interface.Autofac.IContainer</param>
        private static void BuildServiceContainer(IContainer container)
        {
            var serviceLocator = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }
    }
}
