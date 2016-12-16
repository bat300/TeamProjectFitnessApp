using FitnessDietApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    public class CalculateNorm: ICalculateNorm
    {
        
        public void CalculateNorms(PersonInfo personInfo, PersonNorm personNorm)
        {
            if (personInfo.Gender == PersonInfo.PersonsGender.Female) // female            
                personNorm.Calories = (655 + (9.6 * personInfo.Weight) + (1.8 * personInfo.Height) - (4.7 * personInfo.Age));
            else //male
                personNorm.Calories = (66 + (13.7 * personInfo.Weight) + (5 * personInfo.Height) - (6.8 * personInfo.Age));


            switch (personInfo.Lifestyle)
            {
                case PersonInfo.StylesOfLife.NoSport: //низкая активность
                    personNorm.Calories = personNorm.Calories * 1.20;// Магические числа - это плохо
                    break;
                case PersonInfo.StylesOfLife.LightSport: // малая активность
                    personNorm.Calories = personNorm.Calories * 1.38;
                    break;
                case PersonInfo.StylesOfLife.RegularSport: // средняя
                    personNorm.Calories = personNorm.Calories * 1.55;
                    break;
                case PersonInfo.StylesOfLife.EveryDaySport: // высокая
                    personNorm.Calories = personNorm.Calories * 1.73;
                    break;
                default:
                    throw new Exception("Error occured!");
            }

            personNorm.CaloriesLow = personNorm.Calories - 250;
            personNorm.CaloriesUp = personNorm.Calories + 100;

            personNorm.ProteinsLow = personNorm.CaloriesLow * 0.3 / 4;
            personNorm.ProteinsUp = personNorm.CaloriesUp * 0.35 / 4;

            personNorm.FatLow = personNorm.CaloriesLow * 0.15 / 9;
            personNorm.FatUp = personNorm.CaloriesUp * 0.2 / 9;

            personNorm.CarbohydratesLow = personNorm.CaloriesLow * 0.45 / 4;
            personNorm.CarbohydratesUp = personNorm.CaloriesUp * 0.5 / 4;

        }
    }  
}


        