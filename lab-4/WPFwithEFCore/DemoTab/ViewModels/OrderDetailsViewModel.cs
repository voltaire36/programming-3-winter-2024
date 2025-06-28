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