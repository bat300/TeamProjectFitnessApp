using FitnessDietApp.Data;
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
    /// Логика взаимодействия для PageWithPersonalData.xaml
    /// </summary>
    public partial class PageWithPersonalData : Page {
        protected PersonInfo person = new PersonInfo();
        protected PersonNorm Norm = new PersonNorm();
        protected bool canContinue = false;

        public PageWithPersonalData() {
            InitializeComponent();
            ChooseGender.Items.Add("Мужской");
            ChooseGender.Items.Add("Женский");
            ChooseLifestyle.Items.Add("Сидячий образ жизни");
            ChooseLifestyle.Items.Add("Легкие тренировки 1-3 раза в неделю");
            ChooseLifestyle.Items.Add("Умеренные тренировки 3-5 раз в неделю");
            ChooseLifestyle.Items.Add("Интенсивные тренировки 5-7 раз в неделю");
        }

        private void Count_Click(object sender, RoutedEventArgs e) {
            try {
                canContinue = false;

                person.Age = int.Parse(Age.Text);
                person.Weight = double.Parse(Weight.Text);
                person.Height = int.Parse(Height.Text);
                person.Gender = PersonInfo.GetGenderFromString((string)ChooseGender.SelectedItem);
                person.Lifestyle = PersonInfo.GetLifestyleFromString((string)ChooseLifestyle.SelectedItem);
                CalculateNorm calc = new CalculateNorm();
                calc.CalculateNorms(person, Norm);
                Norma.Content = Norm.Calories.ToString();

                canContinue = true;
            } catch (Exception ex) {
                MessageBox.Show("Введены некорректные данные");
            }
        }

        private void GoToPageWithRation_Click(object sender, RoutedEventArgs e) {
            if (canContinue) {
                using (var context = new Context()) {
                    context.Database.ExecuteSqlCommand("DELETE FROM Diary");
                    context.Database.ExecuteSqlCommand("DELETE FROM DiaryItems");
                    context.Database.ExecuteSqlCommand("DELETE FROM PersonInfo");

                    context.PersonInfo.Add(person);
                    context.PersonNorms.Add(Norm);

                    context.SaveChanges();
                }
            } else
                MessageBox.Show("Введены некорректные данные");
        }
    }
}
