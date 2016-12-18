using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FitnessDietApp.Data;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace FitnessDietApp.UI {
    /// <summary>
    /// Логика взаимодействия для PageWithRation.xaml
    /// </summary>
    public partial class PageWithRation : Page {
        public Diary ChoosenDiary { get; set; }

        protected ObservableCollection<string> ProductNames { get; private set; }


        public PageWithRation() {
            InitializeComponent();
            using (var context = new Context()) {
                ProductNames = new ObservableCollection<string>(from product in context.Products.ToList() select product.Name);
            }
        }


        public void Init() {
            using (var context = new Context()) {
                if ((context.Diary.Count() != 0) && (context.Diary.ToList().Last().Date == DateTime.Now.Date))
                    ChoosenDiary = context.Diary.Include("DiaryItems").Include("DiaryItems.Product").ToList().Last();
                else
                    ChoosenDiary = new Diary() { Date = DateTime.Now.Date };

                ChoosenDiary.PersonNorm = context.PersonNorms.ToList().Last();

                if (context.Diary.Count() == 0) {
                    GoToPageWithDiary.IsEnabled = false;
                }
                if (context.Diary.Count() < 2) {
                    GoToPageOfAnalysis.IsEnabled = false;
                }
            }

            Date.Content = string.Format("Дата: {0}", ChoosenDiary.Date.ToString("dd.MM.yyyy"));
            ChosenProductsGrid.ItemsSource = ChoosenDiary.DiaryItems;
            ProductName.ItemsSource = ProductNames;
        }


        private void AddProductToTheTable_Click(object sender, RoutedEventArgs e) {
            try {
                if (int.Parse(ProductWeight.Text) <= 0)
                    throw new Exception();
                IEnumerable<DiaryItem> diaryItem;
                if ((ChoosenDiary.DiaryItems.Count != 0) && ((diaryItem = ChoosenDiary.DiaryItems.Where(
                    item => item.Product.Name == ProductName.Text)).Count() != 0)) {
                    diaryItem.First().Quantity += int.Parse(ProductWeight.Text);
                    ChosenProductsGrid.Items.Refresh();
                } else {
                    using (var context = new Context()) {
                        if (!ProductNames.Contains(ProductName.Text))
                            throw new Exception();

                        ChoosenDiary.DiaryItems.Add(new DiaryItem() {
                            Product = new Products() { Name = ProductName.Text },
                            Quantity = int.Parse(ProductWeight.Text)
                        });
                    }
                }

                ProductName.Text = "";
                ProductWeight.Text = "";
                ProductWeight.Background = Brushes.White;
                GoToPageWithDiary.IsEnabled = true;
            } catch (Exception ex) {
                int n;
                if (!ProductNames.Contains(ProductName.Text))
                    MessageBox.Show("Такого продукта нет в списке :(");
                else if (!int.TryParse(ProductWeight.Text, out n))
                    MessageBox.Show("Введён некорректный вес :(");
                else
                    MessageBox.Show("Что-то пошло не так :(");
            }
        }


        private void GoToOtherPage_Click(object sender, RoutedEventArgs e) {
            using (var context = new Context()) {
                if ((context.Diary.Count() != 0) && (context.Diary.ToList().Last().Date == ChoosenDiary.Date)) {
                    context.DiaryItems.RemoveRange(from diaryItem in (context.DiaryItems.ToList())
                                                   where context.Diary.ToList().Last().DiaryItems.Contains(diaryItem)
                                                   select diaryItem);
                    context.Diary.Remove(context.Diary.ToList().Last());
                }

                foreach (var diaryItem in ChoosenDiary.DiaryItems)
                    diaryItem.Product = context.Products.First(product => product.Name == diaryItem.Product.Name);

                context.Diary.Add(ChoosenDiary);
                context.DiaryItems.AddRange(ChoosenDiary.DiaryItems);

                if (context.Diary.Count() >= 2) {
                    GoToPageOfAnalysis.IsEnabled = true;
                }

                context.SaveChanges();
            }
        }
    }
}
