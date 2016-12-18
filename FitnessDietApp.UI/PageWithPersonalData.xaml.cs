using FitnessDietApp.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System;

namespace FitnessDietApp.UI
{
    /// <summary>
    /// Логика взаимодействия для PageWithPersonalData.xaml
    /// </summary>
    public partial class PageWithPersonalData : Page
    {
        protected PersonInfo person;
        protected PersonNorm norm;

        public PageWithPersonalData()
        {
            InitializeComponent();
            ChooseGender.Items.Add("Мужской");
            ChooseGender.Items.Add("Женский");
            ChooseLifestyle.Items.Add("Сидячий образ жизни");
            ChooseLifestyle.Items.Add("Легкие тренировки 1-3 раза в неделю");
            ChooseLifestyle.Items.Add("Умеренные тренировки 3-5 раз в неделю");
            ChooseLifestyle.Items.Add("Интенсивные тренировки 5-7 раз в неделю");
        }


        public void Init()
        {
            using (var context = new Context())
            {
                if (context.PersonInfo.Count() != 0)
                {
                    person = context.PersonInfo.ToList().Last();
                    norm = context.PersonNorms.ToList().Last();

                    Age.Text = person.Age.ToString();
                    Weight.Text = person.Weight.ToString();
                    Height.Text = person.Height.ToString();
                    ChooseGender.SelectedIndex = ChooseGender.Items.IndexOf(PersonInfo.GetStringFromGender(person.Gender));
                    ChooseLifestyle.SelectedIndex = ChooseLifestyle.Items.IndexOf(PersonInfo.GetStringFromLifestyle(person.Lifestyle));
                    Norma.Content = norm.Calories.ToString();

                    GoToPageWithRation.IsEnabled = true;
                }
                else
                {
                    person = new PersonInfo();
                    norm = new PersonNorm();
                    GoToPageWithRation.IsEnabled = false;
                }
            }
        }


        private void Count_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GoToPageWithRation.IsEnabled = false;

                person.Age = int.Parse(Age.Text);
                person.Weight = double.Parse(Weight.Text);
                person.Height = int.Parse(Height.Text);
                person.Gender = PersonInfo.GetGenderFromString((string)ChooseGender.SelectedItem);
                person.Lifestyle = PersonInfo.GetLifestyleFromString((string)ChooseLifestyle.SelectedItem);
                var calc = Factory.Default.GetCalculateNorm();
                calc.CalculateNorms(person, norm);
                Norma.Content = norm.Calories.ToString();

                GoToPageWithRation.IsEnabled = true;
            }

            catch (Exception ex)
            {
                int n;
                if (!int.TryParse(Age.Text, out n))
                    MessageBox.Show("Введён некорректный возраст :(");
                if (!int.TryParse(Weight.Text, out n))
                    MessageBox.Show("Введён некорректный вес :(");
                if (!int.TryParse(Height.Text, out n))
                    MessageBox.Show("Введён некорректный рост :(");
                else
                    MessageBox.Show("Что-то пошло не так :(");
            }
        }


        private void GoToPageWithRation_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new Context())
            {
                context.PersonInfo.Add(person);
                context.PersonNorms.Add(norm);
                context.SaveChanges();
            }
        }
    }
}
