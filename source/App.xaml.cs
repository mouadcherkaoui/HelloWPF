using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using HelloWPF.Views;
using HelloWPF.ViewModels;

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider IoC;
        private IServiceCollection Services { get; }
        public App()
        {
            Services = new ServiceCollection();
        }

        protected override void OnStartup(StartupEventArgs e) 
        {
            ConfigureServices();
            IoC.GetRequiredService<MainWindow>().Show();
        }

        private void ConfigureServices()
        {
            Services.AddScoped<MainWindow>();
            Services.AddScoped<MainWindowViewModel>();
            IoC = Services.BuildServiceProvider();
        }

    }
}
