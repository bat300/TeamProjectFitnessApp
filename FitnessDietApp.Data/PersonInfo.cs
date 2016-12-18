using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FitnessDietApp.Data
{
    [Table("PersonInfo")]
    public class PersonInfo
    {
      
        public enum PersonsGender  { Male, Female, Error }
        public enum StylesOfLife { NoSport, LightSport, RegularSport, EveryDaySport}

        public static PersonsGender GetGenderFromString(string stringGender)
        {
             PersonsGender gender = PersonsGender.Female;
             switch (stringGender)
             {
                 case "Мужской":
                     gender = PersonsGender.Male;
                     break;
                 case "Женский":
                     gender = PersonsGender.Female;
                     break;
                 default:
                     throw new Exception("Passed string is not correct");
             }
             return gender;
         }

        public static string GetStringFromGender(PersonsGender gender)
        {
             string stringGender = "";
             switch (gender)
             {
                 case PersonsGender.Male:
                    stringGender = "Мужской";
                     break;
                 case PersonsGender.Female:
                    stringGender = "Женский";
                     break;
             }
             return stringGender;
         }
                
        public static StylesOfLife GetLifestyleFromString(string stringLifestyle)
        {
            StylesOfLife lifestyle = StylesOfLife.NoSport;
            switch (stringLifestyle)
            {
                case "Сидячий образ жизни":
                    lifestyle = StylesOfLife.NoSport;
                    break;
                case "Легкие тренировки 1-3 раза в неделю":
                    lifestyle = StylesOfLife.LightSport;
                    break;
                case "Умеренные тренировки 3-5 раз в неделю":
                    lifestyle = StylesOfLife.RegularSport;
                    break;
                case "Интенсивные тренировки 5-7 раз в неделю":
                    lifestyle = StylesOfLife.EveryDaySport;
                    break;
                default:
                    throw new Exception("Passed string is not correct");
            }
            return lifestyle;
        }

        public static string GetStringFromLifestyle(StylesOfLife lifestyle)
        {
            string stringLifeStyle = "";

            switch (lifestyle)
            {
                case StylesOfLife.NoSport:
                    stringLifeStyle = "Сидячий образ жизни";
                    break;
                case StylesOfLife.LightSport:
                    stringLifeStyle = "Легкие тренировки 1-3 раза в неделю";
                    break;
                case StylesOfLife.RegularSport:
                    stringLifeStyle = "Умеренные тренировки 3-5 раз в неделю";
                    break;
                case StylesOfLife.EveryDaySport:
                    stringLifeStyle = "Интенсивные тренировки 5-7 раз в неделю";
                    break;
            }
            return stringLifeStyle;
        }

        public int Id { get; set; }
        public PersonsGender Gender { get; set; }
        public int Age { get; set; }
        public int Height { get; set; } //см
        public double Weight { get; set; } //кг
        public StylesOfLife Lifestyle { get; set; }

    }
}
