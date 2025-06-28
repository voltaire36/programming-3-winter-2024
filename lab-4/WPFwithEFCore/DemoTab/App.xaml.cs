using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DataAccessLibrary;
using System.IO;
using System.Windows;
using DemoTab.ViewModels;

namespace DemoTab
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            services.AddDbContext<OmsContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OmsDatabase")),
                ServiceLifetime.Transient); // Use transient if each usage requires a new instance, otherwise, consider Scoped or Singleton.

            services.AddSingleton<MainWindowViewModel>(); // Singleton, because we only need one instance.
            services.AddTransient<MainWindow>(); // Transient, as windows are typically opened and closed.
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            var viewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();

            // Set the DataContext of the MainWindow to the MainWindowViewModel.
            mainWindow.DataContext = viewModel;
            mainWindow.Show();
        }
    }
}
