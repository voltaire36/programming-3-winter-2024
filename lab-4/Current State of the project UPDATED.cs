


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













DataAccessLibrary Solution: 






DataAccessLibrary:
    appsettings.json

{
  "ConnectionStrings": {
    "OmsDatabase": "Server=(localdb)\\mssqllocaldb;Database=OmsDb;Trusted_Connection=True;"
  }
}









DataAccessLibrary:
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

        public DbSet<Shopper> Shopper { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<BasketItem> BasketItem { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shopper>()
                .HasKey(s => s.IdShopper); // Defines IdShopper as the primary key for the Shopper entity

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

            // Adjusting precision for decimal properties to match your database schema
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(6, 2)"); // Matching the precision and scale to the database

            modelBuilder.Entity<Basket>()
                .Property(b => b.SubTotal)
                .HasColumnType("decimal(7, 2)"); // Matching the precision and scale to the database

            // If you have any additional configuration for your entities, add them here
        }
    }
}









DataAccessLibrary:
    OmsContextFactory.cs

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DataAccessLibrary
{
    public class OmsContextFactory : IDesignTimeDbContextFactory<OmsContext>
    {
        public OmsContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("OmsDatabase")
                               ?? throw new InvalidOperationException("Connection string 'OmsDatabase' not found.");

            var builder = new DbContextOptionsBuilder<OmsContext>();
            builder.UseSqlServer(connectionString);

            return new OmsContext(builder.Options);
        }
    }
}
















DataAccessLibrary:
    Models folder:
        Basket.cs

using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public class Basket
    {
        [Key]
        public int IdBasket { get; set; }
        public int IdShopper { get; set; }
        public byte Quantity { get; set; }
        [Column(TypeName = "decimal(7, 2)")]
        public decimal SubTotal { get; set; }
        public DateTime OrderDate { get; set; }

        [ForeignKey("IdShopper")]
        public virtual Shopper Shopper { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }

        [NotMapped]
        public string DisplayText => $"{Shopper?.Email} - Basket ID: {IdBasket}";
    }


}









DataAccessLibrary:
    Models folder:
        BasketItem.cs

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataAccessLibrary.Models
{
    public class BasketItem
    {
        [Key]
        public int IdBasketItem { get; set; } // INT in SQL Server maps to int in C#
        public short IdProduct { get; set; } // SMALLINT in SQL Server maps to short in C#
        public byte Quantity { get; set; } // TINYINT in SQL Server maps to byte in C#
        public int IdBasket { get; set; }

        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
        [ForeignKey("IdBasket")]
        public virtual Basket Basket { get; set; }
    }
}













DataAccessLibrary:
    Models folder:
        Product.cs



using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class Product
    {
        [Key]
        public short IdProduct { get; set; } // SMALLINT in SQL Server maps to short in C#
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }

}





DataAccessLibrary:
    Models folder:
        Shopper.cs

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLibrary.Models
{
    public class Shopper
    {
        [Key]
        public int IdShopper { get; set; } // INT in SQL Server maps to int in C#
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


















































DemoTab Solution: 










DemoTab:
    App.xaml

<Application x:Class="DemoTab.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:DemoTab">
    <Application.Resources>

    </Application.Resources>
</Application>








DemoTab:
    App.xaml:
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












DemoTab:
    appsettings.json

{
  "ConnectionStrings": {
    "OmsDatabase": "Server=(localdb)\\mssqllocaldb;Database=OmsDb;Trusted_Connection=True;"
  }
}













DemoTab:
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










DemoTab:
    MainWindow.xaml:

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










DemoTab:
    MainWindow.xaml:
        MainWindow.xaml.cs

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















DemoTab:
    ViewModels folder:
        AddItemToOrderViewModel.cs

using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;


namespace DemoTab.ViewModels
{
    public class AddItemToOrderViewModel : ViewModelBase
    {
        private readonly OmsContext _context;
        private ObservableCollection<Basket> _baskets;
        private Basket _selectedBasket;

        public ObservableCollection<Basket> Baskets
        {
            get => _baskets;
            set => SetProperty(ref _baskets, value);
        }

        public Basket SelectedBasket
        {
            get => _selectedBasket;
            set => SetProperty(ref _selectedBasket, value);
        }

        public AddItemToOrderViewModel(OmsContext context)
        {
            _context = context;
            LoadBasketsAsync();
        }

        private async void LoadBasketsAsync()
        {
            // Define the path to your appsettings.json file
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var appSettingsPath = Path.Combine(basePath, "appsettings.json");

            // Build configuration to read appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(appSettingsPath, optional: false, reloadOnChange: true)
                .Build();

            // Retrieve the connection string
            string connectionString = configuration.GetConnectionString("OmsDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<OmsContext>();
            optionsBuilder.UseSqlServer(connectionString);

            using var context = new OmsContext(optionsBuilder.Options);
            var baskets = await context.Basket.Include(b => b.Shopper).ToListAsync();
            Baskets = new ObservableCollection<Basket>(baskets);
        }

    }

}








DemoTab:
    ViewModels folder:
        MainWindowViewModel.cs

using DemoTab.Commands;
using System.Windows;
using DataAccessLibrary;

namespace DemoTab.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private readonly OrderDetailsViewModel _orderDetailsViewModel;
        private readonly AddItemToOrderViewModel _addItemToOrderViewModel;

        public MainWindowViewModel(OmsContext context)
        {
            // Initialize the view models here, passing the context to both
            _orderDetailsViewModel = new OrderDetailsViewModel(context);
            _addItemToOrderViewModel = new AddItemToOrderViewModel(context); // Correctly pass context here

            // Initialize the commands
            View1Command = new DelegateCommand(ShowOrderDetails);
            View2Command = new DelegateCommand(ShowAddItemToOrder);
            ExitCommand = new DelegateCommand(ExitApp);

            // Set the default ViewModel
            CurrentViewModel = _orderDetailsViewModel;
        }

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public DelegateCommand View1Command { get; private set; }
        public DelegateCommand View2Command { get; private set; }
        public DelegateCommand ExitCommand { get; private set; }

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

















DemoTab:
    ViewModels folder:
        OrderDetailsViewModel.cs


using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
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
                SetProperty(ref _selectedBasket, value);
                LoadBasketItems(value?.IdBasket ?? 0);
            }
        }

        public OrderDetailsViewModel(OmsContext context)
        {
            _context = context;
            LoadBasketsAsync();
        }

        private async void LoadBasketsAsync()
        {
            var baskets = await _context.Basket.Include(b => b.Shopper).ToListAsync();
            Baskets = new ObservableCollection<Basket>(baskets);
        }

        private async void LoadBasketItems(int basketId)
        {
            if (basketId != 0)
            {
                var basketItems = await _context.BasketItem
                                                .Where(bi => bi.IdBasket == basketId)
                                                .Include(bi => bi.Product)
                                                .ToListAsync();
                BasketItems = new ObservableCollection<BasketItem>(basketItems);
            }
            else
            {
                BasketItems?.Clear();
            }
        }
    }

}


















DemoTab:
    ViewModels folder:
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); // Use ?. for null-check
        }

        public event PropertyChangedEventHandler? PropertyChanged; // Marked as nullable

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); // Use ?. for null-check
        }
    }
}


























DemoTab:
    UserControls folder:
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
            <ComboBox Grid.Row="0" Margin="10"
          ItemsSource="{Binding Baskets}"
          DisplayMemberPath="DisplayText"
          SelectedValuePath="IdBasket"
          SelectedItem="{Binding SelectedBasket, Mode=TwoWay}"
          Width="200" VerticalAlignment="Center"/>

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









DemoTab:
    UserControls folder:
        AddItemToOrderView.xaml
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
























DemoTab:
    UserControls folder:
        OrderDetailsView.xaml


<UserControl x:Class="DemoTab.UserControls.OrderDetailsView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             mc:Ignorable="d"
             d:DesignHeight="450" d:DesignWidth="800">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition />
            <ColumnDefinition Width="0*" />
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>

        <StackPanel Margin="10,0,10,0" Orientation="Horizontal">
            <TextBlock Text="Baskets:  " VerticalAlignment="Center" />
            <ComboBox ItemsSource="{Binding Baskets}"
            DisplayMemberPath="DisplayText"
            SelectedValuePath="IdBasket"
            SelectedItem="{Binding SelectedBasket, Mode=TwoWay}"
            Height="22"
            SelectionChanged="ComboBox_SelectionChanged" Width="392"/>
        </StackPanel>



        <DataGrid Grid.Row="1" Margin="10,10,10,10" ItemsSource="{Binding BasketItems}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Basket ID" Binding="{Binding Basket.IdBasket}"/>
                <DataGridTextColumn Header="BasketItem ID" Binding="{Binding IdBasketItem}"/>
                <DataGridTextColumn Header="Product ID" Binding="{Binding Product.IdProduct}"/>
                <DataGridTextColumn Header="Product Name" Binding="{Binding Product.ProductName}"/>
                <DataGridTextColumn Header="Unit Price" Binding="{Binding Product.Price, StringFormat=C}"/>
                <DataGridTextColumn Header="Quantity" Binding="{Binding Quantity}"/>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
</UserControl>




    

    
    


















DemoTab:
    UserControls folder:
        OrderDetailsView.xaml
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        // Here you can handle initialization, event subscriptions, etc.

    }
}























DemoTab:
    Commands folder:
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
        private readonly Func<bool>? _canExecute; // Marked as nullable

        public DelegateCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object? parameter)
        {
            _execute();
        }
    }
}



