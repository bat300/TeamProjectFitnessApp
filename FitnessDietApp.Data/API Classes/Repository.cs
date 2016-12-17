using FitnessDietApp.Data.DTO.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    public class Repository
    {
        const string AppKey = "e62225700467dd10431ad8c55b6a2ca3";
        const string AppId = "ab576e02";


        static string MakeQuery(string query, string calories)
        {
            return $"https://api.edamam.com/search?q={query}&app_id={AppId}&app_key={AppKey}&calories={calories}";
        }

        static string MakeQuery(string query, string calories, string diet, string health)
        {
            return $"https://api.edamam.com/search?q={query}&app_id={AppId}&app_key={AppKey}&calories={calories}&diet={diet}&health={health}";
        }

        public async Task<List<ResultRecipe>> GetInfo(string query, string calories)
        {
            using (var client = new HttpClient())
            {
                // Get in JSON.
                var getResponse = await client.GetStringAsync(MakeQuery(query, calories));
                // Deserialize
                var data = JsonConvert.DeserializeObject<Hits>(getResponse);

                // Convertion from DTO to Model
                List<ResultRecipe> Recipes = new List<ResultRecipe>();
                foreach (var item in data.MatchingResults)
                {
                    ResultRecipe resultRec = new ResultRecipe
                    {
                        RecipeTitle = item.Recipe.RecipeTitle,
                        ImageURL = item.Recipe.ImageURL,
                        RecipeURL = item.Recipe.RecipeURL,
                        Servings = item.Recipe.Servings,
                        Calories = item.Recipe.Calories,
                        Weight = item.Recipe.Weight
                    };
                    Recipes.Add(resultRec);
                }
                return Recipes;
            }
        }

        public async Task<List<ResultRecipe>> GetInfo(string query, string calories, string diet, string health)
        {
            using (var client = new HttpClient())
            {
                // Get in JSON.
                var getResponse = await client.GetStringAsync(MakeQuery(query, calories, diet, health));
                // Deserialize
                var data = JsonConvert.DeserializeObject<Hits>(getResponse);

                // Convertion from DTO to Model
                List<ResultRecipe> Recipes = new List<ResultRecipe>();
                foreach (var item in data.MatchingResults)
                {
                    ResultRecipe resultRec = new ResultRecipe
                    {
                        RecipeTitle = item.Recipe.RecipeTitle,
                        ImageURL = item.Recipe.ImageURL,
                        RecipeURL = item.Recipe.RecipeURL,
                        Servings = item.Recipe.Servings,
                        Calories = item.Recipe.Calories,
                        Weight = item.Recipe.Weight
                    };
                    Recipes.Add(resultRec);
                }
                return Recipes;
            }
        }
    }
}
