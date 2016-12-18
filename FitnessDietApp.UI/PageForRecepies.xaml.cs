using FitnessDietApp.Data;
using FitnessDietApp.Data.DTO;
using FitnessDietApp.Data.DTO.Request;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var item = listBoxForRecepies.SelectedItem;
            if (item != null)
            {
                var listOfRecipesProperties = item.ToString().Split('\n');
                var linq = listOfRecipesProperties[2].Split(' ')[2];
                Process.Start(linq);
            }
            else
            {
                MessageBox.Show("You haven't choosen a product!");
            }
        }


        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (Context cont = new Context())
            {
                try
                {
                    string query = TextBoxProductsForRecipe.Text;
                    PersonNorm p = cont.PersonNorms.ToList().LastOrDefault();
                    int from = (int)(Math.Round(p.CaloriesLow / 6));
                    int to = (int)(Math.Round(p.CaloriesUp / 3));
                    string calories = String.Format($"gte {from}, lte {to}");

                    List<ResultRecipe> result;

                    diet.DietLabel = (string)ComboBoxDiet.SelectedItem;
                    health.HealthLabel = (string)ComboBoxHealth.SelectedItem;

                    if ((string)ComboBoxDiet.SelectedItem == null & (string)ComboBoxHealth.SelectedItem == null) // оба выбраны
                    {
                        result = await repo.GetInfo(query, calories);
                    }

                    else if ((string)ComboBoxDiet.SelectedItem != null & (string)ComboBoxHealth.SelectedItem != null) // оба не выбраны
                    {
                        result = await repo.GetInfo(query, calories, diet.DietLabel, health.HealthLabel);
                    }

                    else // хотя бы один выбран
                    {
                        if ((string)ComboBoxDiet.SelectedItem != null) // т.е. выбран diet
                            result = await repo.GetInfo(query, calories, diet.DietLabel, health.HealthLabel, true);

                        else // т.е. выбран health ((string)ComboBoxDiet.SelectedItem == null) 
                            result = await repo.GetInfo(query, calories, diet.DietLabel, health.HealthLabel, false);
                    }

                    if (result != null && result.Count != 0)
                    {
                        listBoxForRecepies.Items.Clear();
                        foreach (var i in result)
                        {
                            listBoxForRecepies.Items.Add($"\nRecipe: {i.RecipeTitle} \n linq: { i.RecipeURL} \n calories per serving: { i.Calories / i.Servings:F2} \n weight per serving: { i.Weight / i.Servings:F2} ");
                        }
                        result.Clear();
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
}

