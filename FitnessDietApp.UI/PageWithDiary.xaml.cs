using FitnessDietApp.Data;
using FitnessDietApp.Data.Interfaces;
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

namespace FitnessDietApp.UI {
    /// <summary>
    /// Логика взаимодействия для PageWithDiary.xaml
    /// </summary>
    public partial class PageWithDiary : Page
    //белки, жиры, углеводы, калории за день расчитываются в методах класса infoProDaySummarising
    //для вывода в любом случае нужно писать цикл по элементам DBSet Diary, для каждого элемента нужно использовать 
    //эти методы (а все методы для рассчитывания отклонений находятся в классе DeviationsCalculating, 
    //его экземпляр нужно создавать через интерфейс и Factory
    {
        public PageWithDiary() {
            InitializeComponent();
        }

        public void Init() {
            using (var context = new Context()) {
                StringBuilder intervals = new StringBuilder();
                var infoProDaySummarising = new InfoProDaySummarising();
                var deviations = Factory.Default.GetDeviationsCalculating();
                foreach (var diary in context.Diary.Include("PersonNorm").Include("DiaryItems").Include("DiaryItems.Product")) {
                    intervals.Append(string.Format("{0}/{1}/{2}/{3} ",
                        ((diary.PersonNorm.CaloriesUp + diary.PersonNorm.CaloriesLow) / 2).ToString("F2"),
                        ((diary.PersonNorm.FatUp + diary.PersonNorm.FatLow) / 2).ToString("F2"),
                        ((diary.PersonNorm.ProteinsUp + diary.PersonNorm.ProteinsLow) / 2).ToString("F2"),
                        ((diary.PersonNorm.CarbohydratesUp + diary.PersonNorm.CarbohydratesLow) / 2).ToString("F2")));

                    double proteinsPerDay = infoProDaySummarising.ProteinsPerDay(diary.DiaryItems.ToList());
                    double caloriesPerDay = infoProDaySummarising.CalloriesPerDay(diary.DiaryItems.ToList());
                    double fatsPerDay = infoProDaySummarising.FatsPerDay(diary.DiaryItems.ToList());
                    double carbohydratesPerDay = infoProDaySummarising.CarbohydratesPerDay(diary.DiaryItems.ToList());

                    double deviationOfProteinsPerDay = deviations.DeviationOfProteinsPerDay(caloriesPerDay, diary.PersonNorm);
                    double deviationOfFatsPerDay = deviations.DeviationOfFatsPerDay(caloriesPerDay, diary.PersonNorm);
                    double deviationOfCarbohydratesPerDay = deviations.DeviationOfCarbohydratesPerDay(caloriesPerDay, diary.PersonNorm);
                    double deviationOfCalloriesPerDay = deviations.DeviationOfCalloriesPerDay(caloriesPerDay, diary.PersonNorm);

                    FullTableOfComponents.Items.Add(new {
                        ProteinsPerDay = proteinsPerDay,
                        ProteinsColor = GetBrushFromDouble(deviationOfProteinsPerDay),
                        CaloriesPerDay = caloriesPerDay,
                        CaloriesColor = GetBrushFromDouble(deviationOfCalloriesPerDay),
                        FatsPerDay = fatsPerDay,
                        FatsColor = GetBrushFromDouble(deviationOfFatsPerDay),
                        CarbohydratesPerDay = carbohydratesPerDay,
                        CarbohydratesColor = GetBrushFromDouble(deviationOfCarbohydratesPerDay),
                        Date = diary.Date.ToString("dd.MM.yyyy"),
                        Products = string.Concat(from diaryItem in diary.DiaryItems select diaryItem.Product.Name)
                    });
                }

                YourCalculation.Text = intervals.ToString();
            }

        }

        protected static Brush GetBrushFromDouble(double value) {
            if (value < 0)
                return Brushes.Yellow;
            if (value > 0)
                return Brushes.Red;
            else
                return Brushes.Green;
        }
    }
}
