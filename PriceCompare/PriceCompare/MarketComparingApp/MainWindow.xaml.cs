﻿using System;
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
            using (var context = new MarketContext())
            {
                var xmlParser = new FileManager.MarketXmlParser();
                xmlParser.ParseAllXml(context);

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

    }
}
