using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using CartCompare;
using Data;
using FileManager;

namespace MarketComparingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainWindowViewModel = new MainWindowViewModel();
            DataContext = MainWindowViewModel;
        }

        public MainWindowViewModel MainWindowViewModel { get; set; }

        private void OnSelectionChanged_AllItemsDataGrid(object sender, SelectionChangedEventArgs e)
        {
            var source = e.Source as ComboBox;
            var sourceValue = source?.SelectedValue;
            if (sourceValue != null)
            {
                var sourceData = source?.DataContext as ItemInQuantity;
                if (sourceData != null)
                {
                    sourceData.ItemQuantity = (int) sourceValue;
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newAllItemsList = new ObservableCollection<ItemInQuantity>();
            var selectedItems = new List<ItemInQuantity>();
            foreach (var dataGridCellInfo in AllItemsDataGrid.SelectedItems)
            {
                var selectedItem = dataGridCellInfo as ItemInQuantity;
                selectedItems.Add(selectedItem);
            }

            foreach (var dataGridCellInfo in AllItemsDataGrid.Items)
            {
                var itemInQuantity = dataGridCellInfo as ItemInQuantity;
                //If item is selected but a quantity was not chosen, still get the item:
                if (selectedItems.Contains(itemInQuantity) && (itemInQuantity?.ItemQuantity == 0))
                {
                    itemInQuantity.ItemQuantity = 1;
                    MainWindowViewModel.SelectedItems.Add(itemInQuantity);
                    Debug.WriteLine($"Added item: {itemInQuantity.Item.Name}.");
                }
                //if a quantity of zero was chosen, item isn't added to selected list:
                else if (itemInQuantity?.ItemQuantity == 0)
                {
                    newAllItemsList.Add(itemInQuantity);
                }
                //if the quantity is greater than zero, item is added to selected list:
                else if (itemInQuantity?.ItemQuantity > 0)
                {
                    MainWindowViewModel.SelectedItems.Add(itemInQuantity);
                    Debug.WriteLine($"Added item: {itemInQuantity.Item.Name}.");
                }
            }
            MainWindowViewModel.AllItems = newAllItemsList;
            AllItemsDataGrid.DataContext = null;
            SelectedItemsDataGrid.DataContext = null;
            AllItemsDataGrid.DataContext = MainWindowViewModel;
            SelectedItemsDataGrid.DataContext = MainWindowViewModel;
        }
        
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var newSelectedItemsList = new ObservableCollection<ItemInQuantity>();

            foreach (var dataGridCellInfo in SelectedItemsDataGrid.SelectedItems)
            {
                var itemInQuantity = dataGridCellInfo as ItemInQuantity;
                if (itemInQuantity == null)
                {
                    continue;
                }
                itemInQuantity.ItemQuantity = 0;
                MainWindowViewModel.AllItems.Add(itemInQuantity);
                newSelectedItemsList.Add(itemInQuantity);
                Debug.WriteLine($"Removed item: {itemInQuantity?.Item.Name}.");
            }
            foreach (var itemInQuantity in newSelectedItemsList)
            {
                MainWindowViewModel.SelectedItems.Remove(itemInQuantity);
            }
            AllItemsDataGrid.DataContext = null;
            SelectedItemsDataGrid.DataContext = null;
            AllItemsDataGrid.DataContext = MainWindowViewModel;
            SelectedItemsDataGrid.DataContext = MainWindowViewModel;
        }

        //Initializing Database for debug only:
        //private void buttonInitializeDB_Click(object sender, RoutedEventArgs e)
        //{
        //    using (var marketContext = new MarketContext())
        //    {
        //        var xmlParser = new MarketXmlParser();
        //        xmlParser.InitializeDatabase(marketContext);

        //        OnContentChanged(DataContext,DataContext);
        //        MessageBox.Show("Database Initialized.");
        //    }
        //}
    }
}
