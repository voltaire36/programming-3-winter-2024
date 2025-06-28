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
