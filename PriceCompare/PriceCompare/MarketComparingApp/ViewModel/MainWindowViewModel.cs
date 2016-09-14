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

namespace MarketComparingApp
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

            LoadFromDatabaseComparable();

            UpdateDatabaseCommand = new DelegateCommand(UpdateDatabase);
            //UpdateItemListCommand = new DelegateCommand<object>(UpdateItemList);
            OpenCommand = new DelegateCommand(Open);
            ExitCommand = new DelegateCommand(Exit);
            //AddCommand = new DelegateCommand<object>(Add);
            //RemoveCommand = new DelegateCommand(Remove);
            CompareCommand = new DelegateCommand(Compare);
        }

        private List<Store> Stores { get; set; }
        public ObservableCollection<ItemInQuantity> AllItems { get; set; }
        public ObservableCollection<ItemInQuantity> SelectedItems { get; set; }
        public ObservableCollection<Cart> Carts { get; private set; }
        public int[] DropDownItemQuantityMenu { get; }
        public ObservableCollection<ICommandEx> Commands { get; }
        
        private void LoadAllFromDatabase()
        {
            using (var context = new MarketContext())
            {
                Stores = context.Stores.Include(s=>s.Chain).ToList();

                var items = context.Items.Include(i => i.Prices.Select(p => p.Item)).ToList().OrderBy(i => i.Name);
                foreach (var item in items)
                {
                    AllItems.Add(new ItemInQuantity() {Item= item, ItemQuantity = 0});
                }
                OnPropertyChanged(nameof(AllItems));
                OnPropertyChanged(nameof(SelectedItems));
            }
        }
        private void LoadFromDatabaseComparable()
        {
            using (var context = new MarketContext())
            {
                Stores = context.Stores.Include(s => s.Chain).ToList();

                var items = context.Items.Where(i => i.Prices.Count > 8).Include(i => i.Prices.Select(p => p.Item)).ToList().OrderBy(i => i.Name);
                foreach (var item in items)
                {
                    AllItems.Add(new ItemInQuantity() { Item = item, ItemQuantity = 0 });
                }
                OnPropertyChanged(nameof(AllItems));
                OnPropertyChanged(nameof(SelectedItems));
            }
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
        private void Add(object obj)
        {
            var newAllItemsList = new ObservableCollection<ItemInQuantity>();
            var newSelectedItemsList = new ObservableCollection<ItemInQuantity>();
            foreach (var itemInQuantity in AllItems)
            {
                if (itemInQuantity.ItemQuantity == 0)
                {
                    newAllItemsList.Add(itemInQuantity);
                }
                else if (itemInQuantity.ItemQuantity > 0)
                {
                    newSelectedItemsList.Add(itemInQuantity);
                    Debug.WriteLine($"Added item {itemInQuantity.Item.Name}");
                }
            }
            AllItems = newAllItemsList;
            SelectedItems = newSelectedItemsList;
            OnPropertyChanged(nameof(AllItems));
            OnPropertyChanged(nameof(SelectedItems));
        }
        private void Remove()
        {
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
        public DelegateCommand<object> AddCommand { get; }
        public DelegateCommand RemoveCommand { get; }
        public DelegateCommand CompareCommand { get; }
    }
}
