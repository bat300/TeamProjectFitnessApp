using FitnessDietApp.Data.DTO.Response;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    public class Repository
    {
        const string AppKey = "";
        const string AppId = "";

        List<ResultRecipe> recipes = new List<ResultRecipe>();


        static string MakeQuery(string query, string calories)
        {
            return $"https://api.edamam.com/search?q={query}&app_id={AppId}&app_key={AppKey}&calories={calories}";
        }


        static string MakeQuery(string query, string calories, string diet, string health, bool check)
        {
            if (check == true)
                return $"https://api.edamam.com/search?q={query}&app_id={AppId}&app_key={AppKey}&calories={calories}&diet={diet}";
            else
                return $"https://api.edamam.com/search?q={query}&app_id={AppId}&app_key={AppKey}&calories={calories}&health={health}";
        }


        static string MakeQuery(string query, string calories, string diet, string health)
        {
            return $"https://api.edamam.com/search?q={query}&app_id={AppId}&app_key={AppKey}&calories={calories}&diet={diet}&health={health}";
        }


        public async Task<List<ResultRecipe>> GetInfo(string query, string calories)
        {
            using (var client = new HttpClient())
            {
                var getResponse = await client.GetStringAsync(MakeQuery(query, calories));
                var data = JsonConvert.DeserializeObject<Hits>(getResponse);

                return ConvertFromDTOtoModel(data);
            }
        }


        public async Task<List<ResultRecipe>> GetInfo(string query, string calories, string diet, string health, bool check)
        {
            using (var client = new HttpClient())
            {
                var getResponse = await client.GetStringAsync(MakeQuery(query, calories, diet, health, check));
                var data = JsonConvert.DeserializeObject<Hits>(getResponse);

                return ConvertFromDTOtoModel(data);
            }
        }


        public async Task<List<ResultRecipe>> GetInfo(string query, string calories, string diet, string health)
        {
            using (var client = new HttpClient())
            {
                var getResponse = await client.GetStringAsync(MakeQuery(query, calories, diet, health));
                var data = JsonConvert.DeserializeObject<Hits>(getResponse);

                return ConvertFromDTOtoModel(data);
            }
        }


        public List<ResultRecipe> ConvertFromDTOtoModel(Hits data)
        {
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
                recipes.Add(resultRec);
            }
            return recipes;
        }
    }
}
