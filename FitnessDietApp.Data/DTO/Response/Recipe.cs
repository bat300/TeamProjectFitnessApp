using Newtonsoft.Json;

namespace FitnessDietApp.Data.DTO.Response
{
    public class Recipe
    {
        [JsonProperty("label")]
        public string RecipeTitle { get; set; }
        [JsonProperty("image")]
        public string ImageURL { get; set; }
        [JsonProperty("url")]
        public string RecipeURL { get; set; }
        [JsonProperty("calories")]
        public float Calories { get; set; } //kcal
        [JsonProperty("totalWeight")]
        public float Weight { get; set; }
        [JsonProperty("yield")]
        public double Servings { get; set; }
        [JsonProperty("dietLabels")]
        public string[] DietLabels { get; set; }
        [JsonProperty("healthLabels")]
        public string[] HealthLabels { get; set; }
    }
}
