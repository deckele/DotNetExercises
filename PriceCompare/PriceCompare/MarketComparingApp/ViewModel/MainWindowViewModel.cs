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
        public ObservableCollection<Item> Items { get; private set; }
        public ObservableCollection<Cart> Carts { get; private set; }
        
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>();

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
                    Items.Add(item);
                }
            }
        }
    }
}
