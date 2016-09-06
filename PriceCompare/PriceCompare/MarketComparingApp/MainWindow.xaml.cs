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

            DataContext = new MainWindowViewModel();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (var marketContext = new MarketContext())
            {
                var xmlParser = new MarketXmlParser();
                xmlParser.ParseAllXml(marketContext);

                MessageBox.Show("DataBase created");
            }
        }

        private void buttonInitializeDB_Click(object sender, RoutedEventArgs e)
        {
            using (var marketContext = new MarketContext())
            {
                var xmlParser = new MarketXmlParser();
                xmlParser.InitializeDatabase(marketContext);

                MessageBox.Show("Database Initialized.");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource itemViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("itemViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // itemViewSource.Source = [generic data source]
            MarketComparingApp.Market2DataSet market2DataSet = ((MarketComparingApp.Market2DataSet)(this.FindResource("market2DataSet")));
            // Load data into the table Items. You can modify this code as needed.
            MarketComparingApp.Market2DataSetTableAdapters.ItemsTableAdapter market2DataSetItemsTableAdapter = new MarketComparingApp.Market2DataSetTableAdapters.ItemsTableAdapter();
            market2DataSetItemsTableAdapter.Fill(market2DataSet.Items);
            System.Windows.Data.CollectionViewSource itemsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("itemsViewSource")));
            itemsViewSource.View.MoveCurrentToFirst();
        }
    }
}
