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

            DietComboBox.Items.Add("balanced"); // - protein/fat/carb values in 15/35/50 ratio");;
            DietComboBox.Items.Add("high-protein"); // - more than 50% of total calories from proteins");
            DietComboBox.Items.Add("low-carb"); // - less than 20% of total calories from carbs"); 
            DietComboBox.Items.Add("low-fat"); // - less than 15% of total calories from fat");                                               
            
            HealthComboBox.Items.Add("alcohol-free"); // - no alcohol in the recipe");
            HealthComboBox.Items.Add("sugar-conscious"); // - less than 4g of sugar per serving");
            HealthComboBox.Items.Add("vegetarian"); // - no meat/poultry/fish");
            HealthComboBox.Items.Add("vegan");
            //HealthComboBox.Items.Add("dairy-free");
        }

        Repository repo = new Repository();
        SearchInfo searchInfo = new SearchInfo();
        Diet diet = new Diet();
        Health health = new Health();


        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = QueryTextBox.Text;
                int from = 300;
                int to = 1000;
                string calories = String.Format($"gte {from}, lte {to}");
                List<ResultRecipe> result;

                if ((string)DietComboBox.SelectedItem != null)
                {
                    diet.DietLabel = (string)DietComboBox.SelectedItem;
                    health.HealthLabel = (string)HealthComboBox.SelectedItem;

                    result = await repo.GetInfo(query, calories, diet.DietLabel, health.HealthLabel);
                }
                else
                    result = await repo.GetInfo(query, calories);

                if (result != null)
                {
                    foreach (var i in result)
                    {
                        listBox.Items.Add($"\nRecipe: {i.RecipeTitle} \n linq: { i.RecipeURL} \n calories per serving: { i.Calories / i.Servings} \n weight per serving: { i.Weight / i.Servings} ");
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
