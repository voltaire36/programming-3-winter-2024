using DataAccessLibrary;
using DataAccessLibrary.Models;
using DemoTab.Commands;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input; // Ensure this namespace is included for ICommand

namespace DemoTab.ViewModels
{
    public class AddItemToOrderViewModel : ViewModelBase
    {
        private readonly OmsContext _context;
        private ObservableCollection<Basket> _baskets = new ObservableCollection<Basket>();
        private ObservableCollection<Product> _products = new ObservableCollection<Product>();
        private Basket _selectedBasket;
        private Product _selectedProduct;
        private int _quantity;
        public ICommand SaveCommand { get; }

        public ObservableCollection<Basket> Baskets
        {
            get => _baskets;
            set => SetProperty(ref _baskets, value);
        }

        public ObservableCollection<Product> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        public Basket SelectedBasket
        {
            get => _selectedBasket;
            set => SetProperty(ref _selectedBasket, value);
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        public AddItemToOrderViewModel(OmsContext context)
        {
            _context = context;
            SaveCommand = new DelegateCommand(async () => await SaveAsync());
            Task.Run(async () => await InitializeAsync());
        }

        public async Task InitializeAsync()
        {
            await LoadBasketsAsync();
            await LoadProductsAsync();
        }

        private async Task LoadBasketsAsync()
        {
            var baskets = await _context.Basket.Include(b => b.Shopper).ToListAsync();
            Baskets = new ObservableCollection<Basket>(baskets);
        }

        private async Task LoadProductsAsync()
        {
            var products = await _context.Product.ToListAsync();
            Products = new ObservableCollection<Product>(products);
        }

        private async Task SaveAsync()
        {
            if (SelectedBasket != null && SelectedProduct != null && Quantity > 0)
            {
                // Example: Update quantity for the selected product in the selected basket
                var basketItem = await _context.BasketItem.FirstOrDefaultAsync(bi => bi.IdBasket == SelectedBasket.IdBasket && bi.IdProduct == SelectedProduct.IdProduct);
                if (basketItem != null)
                {
                    basketItem.Quantity = (byte)Quantity;
                    await _context.SaveChangesAsync();
                    // Consider adding logic here to update UI or notify the user of success
                }
                else
                {
                    // Handle case where the basket item does not exist
                    // For example, create a new basket item with the specified quantity
                }
            }
            else
            {
                // Handle case where not all selections are made or quantity is not valid
            }
        }
    }
}
