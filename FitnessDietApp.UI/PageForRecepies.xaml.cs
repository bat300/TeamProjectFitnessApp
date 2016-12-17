using FitnessDietApp.Data;
using FitnessDietApp.Data.DTO;
using FitnessDietApp.Data.DTO.Request;
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
    /// Логика взаимодействия для PageForRecepies.xaml
    /// </summary>
    public partial class PageForRecepies : Page
    {
        public PageForRecepies()
        {
            InitializeComponent();

            ComboBoxDiet.Items.Add("balanced"); // protein/fat/carb values in 15/35/50 ratio;
            ComboBoxDiet.Items.Add("high-protein"); // more than 50% of total calories from proteins;
            ComboBoxDiet.Items.Add("low-carb"); // less than 20% of total calories from carbs; 
            ComboBoxDiet.Items.Add("low-fat"); // less than 15% of total calories from fat;                                               

            ComboBoxHealth.Items.Add("alcohol-free"); // - no alcohol in the recipe;
            ComboBoxHealth.Items.Add("sugar-conscious"); // - less than 4g of sugar per serving;
            ComboBoxHealth.Items.Add("vegetarian"); // - no meat/poultry/fish;
            ComboBoxHealth.Items.Add("vegan");

        }

        Repository repo = new Repository();
        SearchInfo searchInfo = new SearchInfo();
        Diet diet = new Diet();
        Health health = new Health();


        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = TextBoxProductsForRecipe.Text;
                int from = 300;
                int to = 1000;
                string calories = String.Format($"gte {from}, lte {to}");
                List<ResultRecipe> result;

                if ((string)ComboBoxDiet.SelectedItem != null)
                {
                    diet.DietLabel = (string)ComboBoxDiet.SelectedItem;
                    health.HealthLabel = (string)ComboBoxHealth.SelectedItem;

                    result = await repo.GetInfo(query, calories, diet.DietLabel, health.HealthLabel);
                }
                else
                    result = await repo.GetInfo(query, calories);

                if (result != null)
                {
                    foreach (var i in result)
                    {
                        listBoxForRecepies.Items.Add($"\nRecipe: {i.RecipeTitle} \n linq: { i.RecipeURL} \n calories per serving: { i.Calories / i.Servings} \n weight per serving: { i.Weight / i.Servings} ");
                    }
                }
                else
                    MessageBox.Show("No information was found");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Enter correct info");
            }
        }
    }
}

