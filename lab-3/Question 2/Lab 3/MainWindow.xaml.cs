using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RestaurantBillCalculator
{
    public partial class MainWindow : Window
    {
        private List<MenuItem> menuItems;
        private List<MenuItem> billItems = new List<MenuItem>();
        private decimal subtotal = 0m;
        private const decimal TaxRate = 0.07m; 

        public MainWindow()
        {
            InitializeComponent();
            LoadMenuItems();
            PopulateComboBoxes();

            // Placeholder text for each ComboBox
            cbBeverage.Text = "Drinks";
            cbAppetizer.Text = "Appetizers";
            cbMainCourse.Text = "Main Course";
            cbDessert.Text = "Desserts";
        }


        private void LogoImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Open URL 
            Process.Start(new ProcessStartInfo("https://ca.jollibeefoods.com/") { UseShellExecute = true });
        }



        private void LoadMenuItems()
        {
            menuItems = new List<MenuItem>
    {
        new MenuItem { Name = "Soda", Price = 1.95m, Category = "Beverage" },
        new MenuItem { Name = "Tea", Price = 1.50m, Category = "Beverage" },
        new MenuItem { Name = "Coffee", Price = 1.25m, Category = "Beverage" },
        new MenuItem { Name = "Mineral Water", Price = 2.95m, Category = "Beverage" },
        new MenuItem { Name = "Juice", Price = 2.50m, Category = "Beverage" },
        new MenuItem { Name = "Milk", Price = 1.50m, Category = "Beverage" },
        new MenuItem { Name = "Buffalo Wings", Price = 5.95m, Category = "Appetizer" },
        new MenuItem { Name = "Buffalo Fingers", Price = 6.95m, Category = "Appetizer" },
        new MenuItem { Name = "Potato Skins", Price = 8.95m, Category = "Appetizer" },
        new MenuItem { Name = "Nachos", Price = 8.95m, Category = "Appetizer" },
        new MenuItem { Name = "Mushroom Caps", Price = 10.95m, Category = "Appetizer" },
        new MenuItem { Name = "Shrimp Cocktail", Price = 12.95m, Category = "Appetizer" },
        new MenuItem { Name = "Chips and Salsa", Price = 6.95m, Category = "Appetizer" },
        new MenuItem { Name = "Seafood Alfredo", Price = 15.95m, Category = "Main Course" },
        new MenuItem { Name = "Chicken Alfredo", Price = 13.95m, Category = "Main Course" },
        new MenuItem { Name = "Chicken Picatta", Price = 13.95m, Category = "Main Course" },
        new MenuItem { Name = "Turkey Club", Price = 11.95m, Category = "Main Course" },
        new MenuItem { Name = "Lobster Pie", Price = 19.95m, Category = "Main Course" },
        new MenuItem { Name = "Prime Rib", Price = 20.95m, Category = "Main Course" },
        new MenuItem { Name = "Shrimp Scampi", Price = 18.95m, Category = "Main Course" },
        new MenuItem { Name = "Turkey Dinner", Price = 13.95m, Category = "Main Course" },
        new MenuItem { Name = "Stuffed Chicken", Price = 14.95m, Category = "Main Course" },
        new MenuItem { Name = "Apple Pie", Price = 5.95m, Category = "Dessert" },
        new MenuItem { Name = "Sundae", Price = 3.95m, Category = "Dessert" },
        new MenuItem { Name = "Carrot Cake", Price = 5.95m, Category = "Dessert" },
        new MenuItem { Name = "Mud Pie", Price = 4.95m, Category = "Dessert" },
        new MenuItem { Name = "Apple Crisp", Price = 5.95m, Category = "Dessert" }
    };
        }



        private void PopulateComboBoxes()
        {
            var beverageItems = menuItems.Where(item => item.Category == "Beverage").ToList();
            cbBeverage.ItemsSource = beverageItems;
            cbBeverage.DisplayMemberPath = "Name";

            var appetizerItems = menuItems.Where(item => item.Category == "Appetizer").ToList();
            cbAppetizer.ItemsSource = appetizerItems;
            cbAppetizer.DisplayMemberPath = "Name";

            var mainCourseItems = menuItems.Where(item => item.Category == "Main Course").ToList();
            cbMainCourse.ItemsSource = mainCourseItems;
            cbMainCourse.DisplayMemberPath = "Name";

            var dessertItems = menuItems.Where(item => item.Category == "Dessert").ToList();
            cbDessert.ItemsSource = dessertItems;
            cbDessert.DisplayMemberPath = "Name";
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox cb && cb.SelectedItem is MenuItem selectedItem)
            {
                billItems.Add(selectedItem);
                dgBill.ItemsSource = null;
                dgBill.ItemsSource = billItems;

                subtotal += selectedItem.Price;
                UpdateTotals();

                cb.SelectedIndex = -1; 
            }
        }

        private void ClearBill_Click(object sender, RoutedEventArgs e)
        {
            billItems.Clear();
            dgBill.ItemsSource = null;

            subtotal = 0m;
            UpdateTotals();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("http://www.yourcompanywebsite.com") { UseShellExecute = true });
        }

        private void UpdateTotals()
        {
            var tax = subtotal * TaxRate;
            var total = subtotal + tax;

            txtSubTotal.Text = subtotal.ToString("C");
            txtTax.Text = tax.ToString("C");
            txtTotal.Text = total.ToString("C");
        }
    }

    public class MenuItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
