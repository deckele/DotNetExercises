using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CartCompare;
using Data;
using FileManager;
using MarketComparingApp.Annotations;
using Microsoft.Win32;

namespace MarketComparingApp.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel()
        {
            Stores = new List<Store>();
            AllItems = new ObservableCollection<ItemInQuantity>();
            SelectedItems = new ObservableCollection<ItemInQuantity>();
            Carts = new ObservableCollection<Cart>();
            DropDownItemQuantityMenu = Enumerable.Range(0, 201).ToArray();
            Commands = new ObservableCollection<ICommandEx>();

            LoadAllFromDatabase(8);

            UpdateDatabaseCommand = new DelegateCommand(UpdateDatabase);
            //UpdateItemListCommand = new DelegateCommand<object>(UpdateItemList);
            OpenCommand = new DelegateCommand(Open);
            ExitCommand = new DelegateCommand(Exit);
            AddCommand = new DelegateCommand(Add);
            RemoveCommand = new DelegateCommand(Remove);
            CompareCommand = new DelegateCommand(Compare);
        }

        private List<Store> Stores { get; set; }
        public ObservableCollection<ItemInQuantity> AllItems { get; set; }
        public ObservableCollection<ItemInQuantity> SelectedItems { get; set; }
        public ObservableCollection<Cart> Carts { get; private set; }
        public int[] DropDownItemQuantityMenu { get; }
        public ObservableCollection<ICommandEx> Commands { get; }

        private void LoadAllFromDatabase(int itemComparability = 2)
        {
            var dataService = new DataManager(itemComparability);

            Stores = dataService.Stores;
            foreach (var item in dataService.Items)
            {
                AllItems.Add(new ItemInQuantity() {Item = item, ItemQuantity = 0});
            }
            OnPropertyChanged(nameof(AllItems));
            OnPropertyChanged(nameof(SelectedItems));
        }

        private void UpdateDatabase()
        {
            var xmlParser = new MarketXmlParser();
            xmlParser.ParseAllXml(@"D:\Emanuel\Documents\Coding\PricesForMarketProject\Selection");

            MessageBox.Show("DataBase created");
            OnPropertyChanged(nameof(AllItems));
            OnPropertyChanged(nameof(SelectedItems));
        }

        private void Open()
        {
            var dialog = new OpenFileDialog { Filter = "Save file|*.xml" };
            if (dialog.ShowDialog() == true)
            {
                //var image = new ImageViewModel(dialog.FileName);
                //Images.Add(image);
                //SelectedImage = image;
            }
        }
        private void Exit()
        {
            Application.Current.MainWindow.Close();
        }

        private void UpdateItemList(object obj)
        {
            MessageBox.Show("updating");
        }
        private void Add()
        {
            var newAllItemsList = new ObservableCollection<ItemInQuantity>();
            var selectedItems = new List<ItemInQuantity>();
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            foreach (var dataGridCellInfo in mainWindow.AllItemsDataGrid.SelectedItems)
            {
                var selectedItem = dataGridCellInfo as ItemInQuantity;
                selectedItems.Add(selectedItem);
            }

            foreach (var dataGridCellInfo in mainWindow.AllItemsDataGrid.Items)
            {
                var itemInQuantity = dataGridCellInfo as ItemInQuantity;
                //If item is selected but a quantity was not chosen, still get the item:
                if (selectedItems.Contains(itemInQuantity) && (itemInQuantity?.ItemQuantity == 0))
                {
                    itemInQuantity.ItemQuantity = 1;
                    SelectedItems.Add(itemInQuantity);
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
                    SelectedItems.Add(itemInQuantity);
                    Debug.WriteLine($"Added item: {itemInQuantity.Item.Name}.");
                }
            }
            AllItems = newAllItemsList;
            mainWindow.AllItemsDataGrid.DataContext = null;
            mainWindow.SelectedItemsDataGrid.DataContext = null;
            mainWindow.AllItemsDataGrid.DataContext = mainWindow.MainWindowViewModel;
            mainWindow.SelectedItemsDataGrid.DataContext = mainWindow.MainWindowViewModel;
        }
        private void Remove()
        {
            var newSelectedItemsList = new ObservableCollection<ItemInQuantity>();
            var mainWindow = (MainWindow)Application.Current.MainWindow;

            foreach (var dataGridCellInfo in mainWindow.SelectedItemsDataGrid.SelectedItems)
            {
                var itemInQuantity = dataGridCellInfo as ItemInQuantity;
                if (itemInQuantity == null)
                {
                    continue;
                }
                itemInQuantity.ItemQuantity = 0;
                mainWindow.MainWindowViewModel.AllItems.Add(itemInQuantity);
                newSelectedItemsList.Add(itemInQuantity);
                Debug.WriteLine($"Removed item: {itemInQuantity?.Item.Name}.");
            }
            foreach (var itemInQuantity in newSelectedItemsList)
            {
                mainWindow.MainWindowViewModel.SelectedItems.Remove(itemInQuantity);
            }
            mainWindow.AllItemsDataGrid.DataContext = null;
            mainWindow.SelectedItemsDataGrid.DataContext = null;
            mainWindow.AllItemsDataGrid.DataContext = mainWindow.MainWindowViewModel;
            mainWindow.SelectedItemsDataGrid.DataContext = mainWindow.MainWindowViewModel;
        }
        private void Compare()
        {
            var cartComparer = new CartComperer();
            Carts = cartComparer.GetValidCarts(SelectedItems, Stores);
            OnPropertyChanged(nameof(Carts));
        }

        public DelegateCommand UpdateDatabaseCommand { get; }
        public DelegateCommand<object> UpdateItemListCommand { get; }
        public DelegateCommand OpenCommand { get; }
        public DelegateCommand ExitCommand { get; }
        public DelegateCommand AddCommand { get; }
        public DelegateCommand RemoveCommand { get; }
        public DelegateCommand CompareCommand { get; }
    }
}
