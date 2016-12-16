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

namespace FitnessDietApp.UI
{
    /// <summary>
    /// Логика взаимодействия для PageWithPersonalData.xaml
    /// </summary>
    public partial class PageWithPersonalData : Page
    {
        public PersonInfo Person { get; set; }
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

        PersonInfo person = new PersonInfo();
        PersonNorm norm = new PersonNorm();
        bool canContinue = false;
       
        private void Count_Click(object sender, RoutedEventArgs e)////Не хватает добавления в бд информации 
            //о человеке через класс PersonInfo,элемент которого должен добавляться в DBSet с соответсвующим названием
            //или я не заметила его??
        { 
            try
            {
                canContinue = false;
                Person.Age = int.Parse(Age.Text);
                Person.Weight = double.Parse(Weight.Text);
                Person.Height = int.Parse(Height.Text);
                Person.Gender = PersonInfo.GetGenderFromString((string)ChooseGender.SelectedItem);
                person.Lifestyle = PersonInfo.GetLifestyleFromString((string)ChooseLifestyle.SelectedItem);
                CalculateNorm calc = new CalculateNorm();
                calc.CalculateNorms(person, norm);
                Norma.Content = norm.Calories.ToString();
                canContinue = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введены некорректные данные");
            }
        }

        private void ChooseGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    
        private void GoToTheDiary_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}
