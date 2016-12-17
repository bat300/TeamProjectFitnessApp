using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data.DTO.Request
{
    public class Health
    {
        public string HealthLabel { get; set; }

        //public enum HealthLabels
        //{
        //    Alcohol, AlcoholFree, CeleryFree, CrustceanFree, Dairy, Eggs, Fish, Gluten, KidneyFriendly,
        //    Kosher, LowPotassium, LupineFree, MustardFree, N_A, NoOilAdded, NoSugar, Paleo, Peanuts, Pescatarian,
        //    PorkFree, RedMeatFree, SesameFree, Shellfish, Soy, SugarConscious, TreeNuts, Vegan, Vegetarian, WheatFree
        //}

        //public static HealthLabels GetHealthFromString(string stringHealth)
        //{
        //    HealthLabels health = HealthLabels.Alcohol;
        //    switch (stringHealth)
        //    {
        //        case "No alcohol used or contained in the recipe":
        //            health = HealthLabels.Alcohol;
        //            break;
        //        case "No alcohol used or contained":
        //            health = HealthLabels.AlcoholFree;
        //            break;
        //        case "Does not contain celery or derivatives":
        //            health = HealthLabels.CeleryFree;
        //            break;
        //        case "Does not contain crustaceans (shrimp, lobster etc.) or derivatives":
        //            health = HealthLabels.CrustceanFree;
        //            break;
        //        case "No dairy; no lactose":
        //            health = HealthLabels.Dairy;
        //            break;
        //        case "No eggs or products containing eggs":
        //            health = HealthLabels.Eggs;
        //            break;
        //        case "No fish or fish derivatives":
        //            health = HealthLabels.Fish;
        //            break;
        //        case "No ingredients containing gluten":
        //            health = HealthLabels.Gluten;
        //            break;
        //        case "Per serving – phosphorus less than 250 mg AND potassium less than 500 mg AND sodium: less than 500 mg":
        //            health = HealthLabels.KidneyFriendly;
        //            break;
        //        case "Contains only ingredients allowed by the kosher diet. However it does not guarantee kosher preparation of the ingredients themselves":
        //            health = HealthLabels.Kosher;
        //            break;
        //        case "Less than 150mg per serving":
        //            health = HealthLabels.LowPotassium;
        //            break;
        //        case "Does not contain lupine or derivatives":
        //            health = HealthLabels.LupineFree;
        //            break;
        //        case "Does not contain mustard or derivatives":
        //            health = HealthLabels.MustardFree;
        //            break;
        //        case "No oil added except to what is contained in the basic ingredients":
        //            health = HealthLabels.NoOilAdded;
        //            break;
        //        case "No simple sugars – glucose, dextrose, galactose, fructose, sucrose, lactose, maltose":
        //            health = HealthLabels.NoSugar;
        //            break;
        //        case "Less than 3g of fat per serving":
        //            health = HealthLabels.N_A;
        //            break;
        //        case "Excludes what are perceived to be agricultural products; grains, legumes, dairy products, potatoes, refined salt, refined sugar, and processed oils":
        //            health = HealthLabels.Paleo;
        //            break;
        //        case "No peanuts or products containing peanuts":
        //            health = HealthLabels.Peanuts;
        //            break;
        //        case "Does not contain meat or meat based products, can contain dairy and fish":
        //            health = HealthLabels.Pescatarian;
        //            break;
        //        case "Does not contain pork or derivatives":
        //            health = HealthLabels.PorkFree;
        //            break;
        //        case "Does not contain beef, lamb, pork, duck, goose, game, horse, and other types of red meat or products containing red meat.":
        //            health = HealthLabels.RedMeatFree;
        //            break;
        //        case "Does not contain sesame seed or derivatives":
        //            health = HealthLabels.SesameFree;
        //            break;
        //        case "No shellfish or shellfish derivatives":
        //            health = HealthLabels.Shellfish;
        //            break;
        //        case "No soy or products containing soy":
        //            health = HealthLabels.Soy;
        //            break;
        //        case "Less than 4g of sugar per serving":
        //            health = HealthLabels.SugarConscious;
        //            break;
        //        case "No tree nuts or products containing tree nuts":
        //            health = HealthLabels.TreeNuts;
        //            break;
        //        case "No meat, poultry, fish, dairy, eggs or honey":
        //            health = HealthLabels.Vegan;
        //            break;
        //        case "No meat, poultry, or fish":
        //            health = HealthLabels.Vegetarian;
        //            break;
        //        case "No wheat, can have gluten though":
        //            health = HealthLabels.WheatFree;
        //            break;
        //        default:
        //            throw new Exception("Passed string is not correct");
        //    }
        //    return health;
        //}

        //public HealthLabels Healths { get; set; }
    }
}
