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
    public class MainWindowViewModel : ObservableObject
    {
        private List<Store> Stores { get; set; }
        public ObservableCollection<ItemViewModel> AllItems { get; private set; }
        public ObservableCollection<ItemViewModel> SelectedItems { get; private set; }
        public int[] ItemQuantity { get; }
        public ObservableCollection<Cart> Carts { get; private set; }
        
        public MainWindowViewModel()
        {
            AllItems = new ObservableCollection<ItemViewModel>();
            SelectedItems = new ObservableCollection<ItemViewModel>();
            ItemQuantity = Enumerable.Range(0,21).ToArray();

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
                    AllItems.Add(new ItemViewModel() {Item= item});
                }
            }
        }
    }
}
