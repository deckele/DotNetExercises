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
using MarketComparingApp.ViewModel;

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
