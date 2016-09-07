using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CartCompare;
using Data;
using MarketComparingApp.Annotations;

namespace MarketComparingApp
{
    class MainWindowViewModel : ObservableObject
    {
        private List<Store> Stores { get; set; }
        public ObservableCollection<Item> AllItems { get; private set; }
        public ObservableCollection<Item> SelectedItems { get; private set; }
        public int[] ItemQuantity { get; }
        public ObservableCollection<Cart> Carts { get; private set; }
        
        public MainWindowViewModel()
        {
            AllItems = new ObservableCollection<Item>();
            SelectedItems = new ObservableCollection<Item>();
            ItemQuantity = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};

            LoadFromDatabase();
        }

        public void LoadFromDatabase()
        {
            using (var context = new MarketContext())
            {
                Stores = context.Stores.ToList();

                var items = context.Items.Include(p => p.Prices);
                foreach (var item in items)
                {
                    AllItems.Add(item);
                }
            }
        }
    }
}
