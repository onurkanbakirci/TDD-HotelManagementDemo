using Autofac;
using HotelManagementDemo.WPFUI.Services;
using HotelManagementDemo.WPFUI.Services.Abstract;
using HotelManagementDemo.WPFUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManagementDemo.WPFUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();

            /// <summary>
            /// Register services for business logics
            /// </summary>
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<MainWindow>().AsSelf();

            /// <summary>
            /// Register all viewmodels
            /// </summary>s
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(v => (v.Namespace.Contains("ViewModels") && !v.Namespace.StartsWith("I")))
                .As<IViewModel>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var window = scope.Resolve<MainWindow>();
                window.Show();
            }
        }
    }
}
