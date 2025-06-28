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


using DemoTab.ViewModels;

namespace DemoTab.UserControls
{
    public partial class AddItemToOrderView : UserControl
    {
        public AddItemToOrderView()
        {
            InitializeComponent();
            Loaded += async (sender, args) =>
            {
                if (DataContext is AddItemToOrderViewModel viewModel)
                {
                    await viewModel.InitializeAsync();
                }
            };
        }
    }
}
