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
using MarketDataXmlParser;
using Data;

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
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (var marketContext = new MarketContext())
            {
                MessageBox.Show("DataBase created");
                var items = marketContext.Items;
                foreach (var item in items)
                {
                    Console.WriteLine($"item ID:{item.ItemID} item name:{item.Name} Quantity:{item.QuantityInPackage}.");
                }
            }
        }
    }
}
