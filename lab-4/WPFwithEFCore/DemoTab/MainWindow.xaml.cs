using DataAccessLibrary;
using DemoTab.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Windows;



namespace DemoTab
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Assuming you have a method to create and configure the DbContext
            var context = CreateAndConfigureDbContext();
            var mainWindowViewModel = new MainWindowViewModel(context);
            this.DataContext = mainWindowViewModel;
        }

        private OmsContext CreateAndConfigureDbContext()
        {
            // Configuration logic for DbContext
            var optionsBuilder = new DbContextOptionsBuilder<OmsContext>();
            // Assuming you have a method to get the connection string
            var connectionString = GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);

            return new OmsContext(optionsBuilder.Options);
        }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            // Retrieve the connection string
            string connectionString = configuration.GetConnectionString("OmsDatabase");
            return connectionString;
        }

    }
}