using FitnessDietApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    //ИНТЕРФЕЙС ПОДСЧЁТА
    public class InfoProDaySummarising
        
    {

        public Diary DaysDiary { get; set; }

        public double ProteinsPerDay(List<DiaryItem> diaryItem)
        {
            double protein = 0;
            foreach (var item in diaryItem)
            {
                protein += item.Product.Proteins * item.Quantity / 100;
            }
            return protein;
        }

        public double FatsPerDay(List<DiaryItem> diaryItem)
        {
            double fat = 0;
            foreach (var item in diaryItem)
            {
                fat += item.Product.Fat * item.Quantity / 100;
            }
            return fat;
        }

        public double CarbohydratesPerDay(List<DiaryItem> diaryItems)
        {
            double carbohydrate = 0;
            foreach (var item in diaryItems)
            {
                carbohydrate += item.Product.Carbohydrates * item.Quantity / 100;
            }
            return carbohydrate;
        }
        /*
        public double DeviationOfProteinsPerDay(double ProteinsProDay, PersonNorm norms)
        {
            if (ProteinsProDay > norms.ProteinsUp)
            {
                return (ProteinsProDay - norms.ProteinsUp);
            }
            else
                    if (ProteinsProDay < norms.ProteinsLow)
            {
                return( ProteinsProDay - norms.ProteinsLow);
            }
            else
                return 0;
        }

        public double DeviationOfFatsPerDay(double FatsProDay, PersonNorm norms)
        {
            if (FatsProDay > norms.FatUp)
            {
                return (FatsProDay - norms.FatUp);
            }
            else
                    if (FatsProDay < norms.FatLow)
            {
                return (FatsProDay - norms.FatLow);
            }
            else
                return 0;
        }

        public double DeviationOfCarbohydratesPerDay(double CarbohydratesProDay, PersonNorm norms)
        {
            if (CarbohydratesProDay > norms.CarbohydratesUp)
            {
                return( CarbohydratesProDay - norms.CarbohydratesUp);
            }
            else
                    if (CarbohydratesProDay < norms.CarbohydratesLow)
            {
                return( CarbohydratesProDay - norms.CarbohydratesLow);
            }
            else
                return 0;
        }*/

        public double CalloriesPerDay(List<DiaryItem> diaryItem)
        {
            double callory = 0;
            foreach (var item in diaryItem)
            {
                callory += item.Product.Сalories * item.Quantity / 100;
            }
            return callory;
        }
        /*
        public double DeviationOfCalloriesPerDay(double CalloriesProDay, PersonNorm norms)
        {
            if (CalloriesProDay > norms.CaloriesUp)
            {
                return( CalloriesProDay - norms.CaloriesUp);
            }
            else
                    if (CalloriesProDay < norms.CaloriesLow)
            {
                return( CalloriesProDay - norms.CaloriesLow);
            }
            else
                 return 0;
        }*/

    }
}
