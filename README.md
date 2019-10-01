# HelloWPF

this is a simplified example of a "Hello, world" for WPF application using MVVM.

after generating a new blank wpf app using: **dotnet new wpf -o "outputproject"**
you need to install the DI package, I used the standard one ***Microsoft.Extensions.DependencyInjection*** using this command:

**dotnet add package Microsoft.Extensions.DependencyInjection**

or just install it using Nuget Package manager UI.

next you should register the different views, viewmodels, and services to build the dependency container, all this at the StartUp of the application: 

````C#
    public partial class App : Application
    {
        // the static IoC field
        public static IServiceProvider IoC;

        // we declare a private IServiceCollection property
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

        // here we register the required services and depedencies
        private void ConfigureServices()
        {
            Services.AddScoped<MainWindow>();
            Services.AddScoped<MainWindowViewModel>();

            IoC = Services.BuildServiceProvider();
        }

    }
````