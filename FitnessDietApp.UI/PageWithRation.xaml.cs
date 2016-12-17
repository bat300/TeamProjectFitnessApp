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
using System.Collections.ObjectModel;

namespace FitnessDietApp.UI {
    /// <summary>
    /// Логика взаимодействия для PageWithRation.xaml
    /// </summary>
    public partial class PageWithRation : Page
    //в UI когда пользователь пишет продукт и количество, создаёшь объект Diary Item ; 
    //потом создаёшь объект класса Diary с этим DiaryItem! Если такой продукт в этот день уже есть, прибавляешь количество.
    // При создании объекта дневника нужно в графу с PersonNorm записывать последнюю занесённую норму!!!!!!!!!!!!!!!!!!!!!!
    //(последний объект в DbSet PersonNorm)!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //Если ни одной записи в дневнике нет, нельзя показать анализ, выводить сообщение мб или сделать кнопку доступной 
    //после первого добавления продукта

    {
        public Diary ChoosenDiary { get; set; }

        public ObservableCollection<string> ProductNames { get; private set; }

        bool canContinue = false;

        public PageWithRation() {
            InitializeComponent();
        }

        public void Init() {
            using (var context = new Context()) {
                if ((context.Diary.Count() != 0) && (context.Diary.ToList().Last().Date == DateTime.Now.Date))
                    ChoosenDiary = context.Diary.Last();
                else
                    ChoosenDiary = new Diary() { Date = DateTime.Now.Date };

                ProductNames = new ObservableCollection<string>(from product in context.Products.ToList() select product.Name);
                ChoosenDiary.PersonNorm = context.PersonNorms.ToList().Last();
            }

            Date.Content = string.Format("Дата: {0}", ChoosenDiary.Date.ToString("dd.MM.yyyy"));
            ChosenProductsGrid.ItemsSource = ChoosenDiary.DiaryItems;
            ProductName.ItemsSource = ProductNames;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
        }

        private void AddProductToTheTable_Click(object sender, RoutedEventArgs e) {
            try {
                IEnumerable<DiaryItem> diaryItem;
            if ((ChoosenDiary.DiaryItems.Count != 0) && ((diaryItem = ChoosenDiary.DiaryItems.Where(item => item.Product.Name == ProductName.Text)).Count() != 0)) {
                diaryItem.First().Quantity += int.Parse(ProductWeight.Text);
                ChosenProductsGrid.Items.Refresh();
            }  else
                ChoosenDiary.DiaryItems.Add(new DiaryItem() { Product = new Products { Name = ProductName.Text }, Quantity = int.Parse(ProductWeight.Text) });
                ProductName.Text = "";
                ProductWeight.Text = "";
            } catch (Exception ex) {
                MessageBox.Show("Необходимо заполнить оба поля ввода");
            }
        }
    }
}
