



Project Structure:



Solution "WPFwithEFCore" (2 projects)
├──📁 DataAccessLibrary (Class Library)
│   ├──📁 Migrations
│   │   ├──📄 20240331010744_InitialCreate.cs
│   │   ├──📄 20240331010744_InitialCreate.Designer.cs
│   │   └──📄 OmsContextModelSnapshot.cs
│   ├──📁 Models
│   │   ├──📄 Basket.cs
│   │   ├──📄 BasketItem.cs
│   │   ├──📄 Product.cs
│   │   └──📄 Shopper.cs
│   └──📄 OmsContextFactory.cs
│   └──📄 OmsContext.cs
└──📁 DemoTab (WPF Application)
    ├──📁 Dependencies
    ├──📁 Commands
    │   └──📄 DelegateCommand.cs
    ├──📁 UserControls
    │   ├──📄 AddItemToOrderView.xaml
    │   │   └──📄 AddItemToOrderView.xaml.cs
    │   └──📄 OrderDetailsView.xaml
    │       └──📄 OrderDetailsView.xaml.cs
    ├──📁 ViewModels
    │   ├──📄 AddItemToOrderViewModel.cs
    │   ├──📄 OrderDetailsViewModel.cs
    │   ├──📄 MainWindowViewModel.cs
    │   └──📄 ViewModelBase.cs
    ├──📄 App.xaml
    │   └──📄 App.xaml.cs
    ├──📄 AssemblyInfo.cs
    ├──📄 MainWindow.xaml
    │   └──📄 MainWindow.xaml.cs
    └─────appsettings.json 












DataAccessLibrary:




appsettings.json



{
  "ConnectionStrings": {
    "OmsDatabase": "Server=(localdb)\\mssqllocaldb;Database=OmsDb;Trusted_Connection=True;"
  }
}












OmsContext.cs


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccessLibrary.Models;
using System.Configuration;



namespace DataAccessLibrary
{
    public class OmsContext : DbContext
    {
        // Constructor accepting DbContextOptions and passing it to the base DbContext constructor
        public OmsContext(DbContextOptions<OmsContext> options) : base(options)
        {
        }

        public DbSet<Shopper> Shoppers { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shopper>()
                .HasKey(s => s.IdShopper); // This defines IdShopper as the primary key for the Shopper entity

            modelBuilder.Entity<Basket>()
                .HasKey(b => b.IdBasket);

            modelBuilder.Entity<BasketItem>()
                .HasKey(bi => bi.IdBasketItem);

            modelBuilder.Entity<Basket>()
                .HasOne(b => b.Shopper)
                .WithMany(s => s.Baskets)
                .HasForeignKey(b => b.IdShopper);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.IdProduct);

            // Define precision for decimal properties
            modelBuilder.Entity<Basket>()
                .Property(b => b.SubTotal)
                .HasPrecision(18, 2); // Or use .HasColumnType("decimal(18, 2)") if you prefer

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2); // Or use .HasColumnType("decimal(18, 2)")

            // Add configurations for other entities as necessary
        }
    }
}











📄 OmsContextFactory.cs


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataAccessLibrary
{
    public class OmsContextFactory : IDesignTimeDbContextFactory<OmsContext>
    {
        public OmsContext CreateDbContext(string[] args)
        {
            // As appsettings.json is now local to DataAccessLibrary, no need to adjust the path
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var builder = new DbContextOptionsBuilder<OmsContext>();
            var connectionString = configuration.GetConnectionString("OmsDatabase");

            builder.UseSqlServer(connectionString);

            return new OmsContext(builder.Options);
        }
    }
}















Models Folder:
Basket.cs

using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace DataAccessLibrary.Models
{
    public class Basket
    {
        [Key] // Explicitly defining the primary key
        public int IdBasket { get; set; }

        // Assuming IdShopper is a foreign key to the Shopper entity
        public int IdShopper { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime OrderDate { get; set; }

        // Navigation properties
        public virtual Shopper Shopper { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }
}








Models Folder:
BasketItem.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataAccessLibrary.Models
{
    public class BasketItem
    {
        public int IdBasketItem { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public int IdBasket { get; set; }
        public virtual Basket Basket { get; set; }
        public virtual Product Product { get; set; }
    }

}










Models Folder:
Product.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;








namespace DataAccessLibrary.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }
}












Models Folder:
Shopper.cs


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLibrary.Models
{
    public class Shopper
    {
        public int IdShopper { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }
    }
}










































DemoTab:


MainWindow.xaml



<Window x:Class="DemoTab.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:DemoTab.UserControls"
        xmlns:viewModel="clr-namespace:DemoTab.ViewModels"
        mc:Ignorable="d"
        Title="Order Manager" Height="450" Width="800">

    <Window.Resources>
        <!-- DataTemplate for the OrderDetailsViewModel -->
        <DataTemplate DataType="{x:Type viewModel:OrderDetailsViewModel}">
            <local:OrderDetailsView />
        </DataTemplate>
        <!-- DataTemplate for the AddItemToOrderViewModel -->
        <DataTemplate DataType="{x:Type viewModel:AddItemToOrderViewModel}">
            <local:AddItemToOrderView />
        </DataTemplate>
    </Window.Resources>

    <Window.DataContext>
        <viewModel:MainWindowViewModel />
    </Window.DataContext>

    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="60" />
            <RowDefinition Height="50" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>

        <Border Background="CadetBlue">
            <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                <TextBlock Text="Order Manager"
                           FontSize="24"
                           VerticalAlignment="Center"
                           FontFamily="Ink Free" />
            </StackPanel>
        </Border>

        <StackPanel Grid.Row="1" Orientation="Horizontal">
            <Button Content="List Order Details"
                    Width="150"
                    Background="CornflowerBlue"
                    Foreground="Yellow"
                    Command="{Binding View1Command }"/>
            <Button Content="Add Item to Order"
                    Width="150"
                    Background="LightBlue"
                    Foreground="Yellow"
                    Command="{Binding View2Command }"/>
            <Button Content="Exit"
                    Width="150"
                    Background="CornflowerBlue"
                    Foreground="Yellow"
                    Command="{Binding ExitCommand }"/>
        </StackPanel>

        <ContentControl Grid.Row="2" Content="{Binding CurrentViewModel}"/>
    </Grid>
</Window>













MainWindow.xaml.cs  


using System.Windows;

namespace DemoTab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}












App.xaml 


<Application x:Class="DemoTab.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:DemoTab"
             StartupUri="MainWindow.xaml">
    <Application.Resources>
         
    </Application.Resources>
</Application>






App.xaml.cs

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










AssemblyInfo.cs 




using System.Windows;

[assembly: ThemeInfo(
    ResourceDictionaryLocation.None,            //where theme specific resource dictionaries are located
                                                //(used if a resource is not found in the page,
                                                // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly   //where the generic resource dictionary is located
                                                //(used if a resource is not found in the page,
                                                // app, or any theme specific resource dictionaries)
)]






App.config


<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<connectionStrings>
		<add name="OmsDatabase"
             connectionString="Server=(localdb)\\mssqllocaldb;Database=OmsDb;Trusted_Connection=True;"
             providerName="System.Data.SqlClient" />
	</connectionStrings>
</configuration>
















    ViewModels Folder:
    AddItemToOrderViewModel.cs


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTab.ViewModels
{
    // Renamed from CourseViewModel to AddItemToOrderViewModel
    public class AddItemToOrderViewModel : ViewModelBase
    {
        // Properties and methods for adding items to an order will go here
    }
}







ViewModels Folder:
MainWindowViewModel.cs


using DemoTab.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataAccessLibrary;

namespace DemoTab.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private readonly OrderDetailsViewModel _orderDetailsViewModel;
        private readonly AddItemToOrderViewModel _addItemToOrderViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public DelegateCommand View1Command { get; private set; }
        public DelegateCommand View2Command { get; private set; }
        public DelegateCommand ExitCommand { get; private set; }

        public MainWindowViewModel(OmsContext context)
        {
            // Initialize the view models here
            _orderDetailsViewModel = new OrderDetailsViewModel(context);
            _addItemToOrderViewModel = new AddItemToOrderViewModel();

            // Initialize the commands
            View1Command = new DelegateCommand(ShowOrderDetails);
            View2Command = new DelegateCommand(ShowAddItemToOrder);
            ExitCommand = new DelegateCommand(ExitApp);

            // Set the default ViewModel
            CurrentViewModel = _orderDetailsViewModel;
        }

        private void ShowOrderDetails()
        {
            CurrentViewModel = _orderDetailsViewModel;
        }

        private void ShowAddItemToOrder()
        {
            CurrentViewModel = _addItemToOrderViewModel;
        }

        private void ExitApp()
        {
            Application.Current.Shutdown();
        }
    }
}











ViewModels Folder:


OrderDetailsViewModel.cs

using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DemoTab.ViewModels
{
    public class OrderDetailsViewModel : ViewModelBase
    {
        private readonly OmsContext _context;
        private ObservableCollection<Basket> _baskets;
        private ObservableCollection<BasketItem> _basketItems;
        private Basket _selectedBasket;

        public ObservableCollection<Basket> Baskets
        {
            get => _baskets;
            set => SetProperty(ref _baskets, value);
        }

        public ObservableCollection<BasketItem> BasketItems
        {
            get => _basketItems;
            set => SetProperty(ref _basketItems, value);
        }

        public Basket SelectedBasket
        {
            get => _selectedBasket;
            set
            {
                if (SetProperty(ref _selectedBasket, value))
                {
                    LoadBasketItems(value.IdBasket).ConfigureAwait(false);
                }
            }
        }

        public OrderDetailsViewModel(OmsContext context)
        {
            _context = context;
            LoadBaskets().ConfigureAwait(false);
        }

        private async Task LoadBaskets()
        {
            var baskets = await _context.Baskets.Include(b => b.Shopper).ToListAsync();
            Baskets = new ObservableCollection<Basket>(baskets);
        }

        private async Task LoadBasketItems(int basketId)
        {
            var basketItems = await _context.BasketItems
                .Where(bi => bi.IdBasket == basketId)
                .Include(bi => bi.Product)
                .ToListAsync();
            BasketItems = new ObservableCollection<BasketItem>(basketItems);
        }
    }
}

















ViewModels Folder:
ViewModelBase.cs


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoTab.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    { 
        protected virtual void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, val)) return;
            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}









UserControls Folder:
AddItemToOrderView.xaml

<UserControl x:Class="DemoTab.UserControls.AddItemToOrderView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
             mc:Ignorable="d"
             d:DesignHeight="450"
             d:DesignWidth="800">
    <!-- Assuming you have styles defined in your App.xaml -->
    <UserControl.Resources>
        <Style x:Key="ButtonStyle" TargetType="Button">
            <Setter Property="Background" Value="CornflowerBlue"/>
            <Setter Property="Foreground" Value="White"/>
            <Setter Property="BorderBrush" Value="Transparent"/>
            <Setter Property="Padding" Value="10,5"/>
            <Setter Property="Margin" Value="5"/>
            <Setter Property="BorderThickness" Value="1"/>
            <Setter Property="FontWeight" Value="Bold"/>
            <Setter Property="FontSize" Value="14"/>
            <!-- Set any other properties to match your design -->
        </Style>
    </UserControl.Resources>

    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>

        <StackPanel Grid.Row="0" Orientation="Horizontal" HorizontalAlignment="Center" Margin="10">
            <TextBlock Text="Basket:" VerticalAlignment="Center" Margin="5"/>
            <ComboBox Width="200" VerticalAlignment="Center"/>
            <!-- Placeholder for Basket ComboBox -->
        </StackPanel>

        <StackPanel Grid.Row="1" Orientation="Horizontal" HorizontalAlignment="Center" Margin="10">
            <TextBlock Text="Product:" VerticalAlignment="Center" Margin="5"/>
            <ComboBox Width="200" VerticalAlignment="Center"/>
            <!-- Placeholder for Product ComboBox -->
        </StackPanel>

        <StackPanel Grid.Row="2" Orientation="Horizontal" HorizontalAlignment="Center" Margin="10">
            <TextBlock Text="Quantity:" VerticalAlignment="Center" Margin="5"/>
            <TextBox Width="200" VerticalAlignment="Center"/>
            <!-- Placeholder for Quantity TextBox -->
        </StackPanel>

        <StackPanel Grid.Row="4" Orientation="Horizontal" HorizontalAlignment="Center" Margin="10">
            <Button Content="Save" Width="100" Style="{StaticResource ButtonStyle}" />
            <Button Content="Cancel" Width="100" Style="{StaticResource ButtonStyle}" />
        </StackPanel>
    </Grid>
</UserControl>











UserControls Folder:
AddItemToOrderView.xaml.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoTab.UserControls
{
    /// <summary>
    /// Interaction logic for AddItemToOrderView.xaml
    /// </summary>
    public partial class AddItemToOrderView : UserControl
    {
        public AddItemToOrderView()
        {
            InitializeComponent();
        }

        // Implement event handlers and other functionality as needed

    }
}













UserControls Folder:
OrderDetailsView.xaml

<UserControl x:Class="DemoTab.UserControls.OrderDetailsView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
             mc:Ignorable="d"
             d:DesignHeight="450" d:DesignWidth="800">
    <Grid>
        <!-- Define margins and rows/columns as needed -->
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <!-- For ComboBox and Label -->
            <RowDefinition Height="*"/>
            <!-- For DataGrid -->
        </Grid.RowDefinitions>

        <!-- Label and ComboBox for Basket selection -->
        <StackPanel Grid.Row="0" Orientation="Horizontal" VerticalAlignment="Top" Margin="10">
            <TextBlock Text="Basket:" VerticalAlignment="Center" Margin="0,0,10,0"/>
            <ComboBox Width="200" />
            <!-- Placeholder for your ComboBox -->
        </StackPanel>

        <!-- DataGrid to display the order details -->
        <DataGrid Grid.Row="1" Margin="10" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Basket ID" />
                <DataGridTextColumn Header="BasketItem ID" />
                <DataGridTextColumn Header="Product ID" />
                <DataGridTextColumn Header="Product Name" />
                <DataGridTextColumn Header="Unit Price" />
                <DataGridTextColumn Header="Quantity" />
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
</UserControl>











UserControls Folder:
OrderDetailsView.xaml.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoTab.UserControls
{
    /// <summary>
    /// Interaction logic for OrderDetailsView.xaml
    /// </summary>
    public partial class OrderDetailsView : UserControl
    {
        public OrderDetailsView()
        {
            InitializeComponent();
        }


        // Here you can handle initialization, event subscriptions, etc.

    }
}









Commands Folder:
DelegateCommand.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoTab.Commands
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public DelegateCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;
            else
                return _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
    }


appsettings.json



{
  "ConnectionStrings": {
    "OmsDatabase": "Server=(localdb)\\mssqllocaldb;Database=OmsDb;Trusted_Connection=True;"
  }
}