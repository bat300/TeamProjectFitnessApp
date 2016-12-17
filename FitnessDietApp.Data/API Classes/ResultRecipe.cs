using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    public class ResultRecipe
    {
        public string RecipeTitle { get; set; }
        public string ImageURL { get; set; }
        public string RecipeURL { get; set; }
        public double Servings { get; set; }  //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!     
        public float Calories { get; set; } //kcal
        public float Weight { get; set; }
    }
}
