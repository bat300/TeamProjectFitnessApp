using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data.DTO.Request
{
    public class Diet
    {
        public string DietLabel { get; set; }

        //public enum DietLabels { Balanced, HighFiber, HighProtein, LowCarb, LowFat, LowSodium }        

        //public static DietLabels GetDietFromString(string stringDiet)
        //{
        //    DietLabels diet = DietLabels.Balanced;
        //    switch (stringDiet)
        //    {
        //        case "Protein/Fat/Carb values in 15/35/50 ratio":
        //            diet = DietLabels.Balanced;
        //            break;
        //        case "More than 5g fiber per serving":
        //            diet = DietLabels.HighFiber;
        //            break;
        //        case "More than 50% of total calories from proteins":
        //            diet = DietLabels.HighProtein;
        //            break;
        //        case "Less than 20% of total calories from carbs":
        //            diet = DietLabels.LowCarb;
        //            break;
        //        case "Less than 15% of total calories from fat":
        //            diet = DietLabels.LowFat;
        //            break;
        //        case "Less than 140mg Na per serving":
        //            diet = DietLabels.LowSodium;
        //            break;
        //        default:
        //            throw new Exception("Passed string is not correct");
        //    }
        //    return diet;            
        //}

        //public DietLabels Diets { get; set; }
    }
}
