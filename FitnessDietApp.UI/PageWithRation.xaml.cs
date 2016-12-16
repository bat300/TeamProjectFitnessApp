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
using FitnessDietApp.Data;
using System.Collections.ObjectModel;

namespace FitnessDietApp.UI
{
    /// <summary>
    /// Логика взаимодействия для PageWithRation.xaml
    /// </summary>
    public partial class PageWithRation : Page
    {
        public ObservableCollection<ProductInfo> ChoosenProductsList = new ObservableCollection<ProductInfo>();

        public ObservableCollection<string> ProductNames { get; private set; }

        public PageWithRation()
        {
            InitializeComponent();
            using (var context = new Context())
            {
                ProductNames = new ObservableCollection<string>(from product in context.Products.ToList() select product.Name);
            }

            ChosenProductsGrid.ItemsSource = ChoosenProductsList;
            ProductName.ItemsSource = ProductNames;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void AddProductToTheTable_Click(object sender, RoutedEventArgs e)
        {
            ChoosenProductsList.Add(new ProductInfo(DateTime.Now.Date.ToString("dd.MM.yy"), ProductName.Text, double.Parse(ProductWeight.Text)));
            ProductName.Text = "";
            ProductWeight.Text = "";
        }
    }
}
