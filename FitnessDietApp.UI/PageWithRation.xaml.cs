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
using FitnessDietApp.Data;

namespace FitnessDietApp.UI
{
    /// <summary>
    /// Логика взаимодействия для PageWithRation.xaml
    /// </summary>
    public partial class PageWithRation : Page
        //в UI когда пользователь пишет продукт и количество, создаёшь объект Diary Item ; 
    //потом создаёшь объект класса Diary с этим DiaryItem! Если такой продукт в этот день уже есть, прибавляешь количество.
    {
        List<ProductInfo> ChoosenProductsList = new List<ProductInfo>();
        public List<string> ProductNames { get; private set; }
        public PageWithRation()
        {
            InitializeComponent();
            using (var context = new Context())
            {
                ProductNames = (from product in context.Products.ToList() select product.Name).ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddProductToTheTable_Click(object sender, RoutedEventArgs e)
        {
            //ChosenProductsGrid.Items.Add(new { Date=DateTime.Now.Date.ToString("dd.MM.yy"), Name=ProductName.Text });
            ChoosenProductsList.Add(new ProductInfo(DateTime.Now.Date.ToString("dd.MM.yy"), ProductName.Text, double.Parse(ProductWeight.Text)));
            ChosenProductsGrid.Items.Add(ChoosenProductsList.Last());
            //ChosenProductsGrid.Items.Refresh();
            ProductName.Text = "";
            ProductWeight.Text = "";
        }
    }
}
