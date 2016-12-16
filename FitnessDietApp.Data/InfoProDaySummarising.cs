using FitnessDietApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    //ИНТЕРФЕЙС ПОДСЧЁТА
    public class InfoProDaySummarising: IInfoProDaySummarising
        
    {
        //public int Id { get; set; }
        //private double proteinsProDay;
        //private double fatsProDay;
        //private double carbohydratesProDay;
        //private double calloriesProDay;
        //private double deviationOfProteinsProDay;
        //private double deviationOfFatsProDay;
        //private double deviationOfCarbohydratesProDay;
        //private double deviationOfCalloriesProDay;

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
        /*
        public double ProteinsProDay
        {
            get
            {
                return proteinsProDay;
            }

            set
            {
                
                double protein = 0;
                foreach(var item in DaysDiary.DiaryItems)
                {
                    protein += item.Product.Proteins * item.Quantity / 100;
                }
                proteinsProDay = protein;
            }
        }
        */
        public double FatsPerDay(List<DiaryItem> diaryItem)
        {
            double fat = 0;
            foreach (var item in diaryItem)
            {
                fat += item.Product.Fat * item.Quantity / 100;
            }
            return fat;
        }
        /*
        public double FatsProDay
        {
            get
            {
                return fatsProDay;
            }

            set
            {
                double fat = 0;
                foreach (var item in DaysDiary.DiaryItems)
                {
                    fat += item.Product.Fat * item.Quantity / 100;
                }
                fatsProDay = fat;
            }
        }
        */
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
        public double CarbohydratesProDay
        {
            get
            {
                return carbohydratesProDay;
            }

            set
            {
                double carbohydrate = 0;
                foreach (var item in DaysDiary.DiaryItems)
                {
                    carbohydrate += item.Product.Carbohydrates * item.Quantity / 100;
                }
                carbohydratesProDay = carbohydrate;
            }
        }*/
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
        /*
        public double DeviationOfProteinsProDay
        {
            get
            {
                return deviationOfProteinsProDay;
            }

            set
            {
                if (ProteinsProDay > DaysDiary.PersonNorm.ProteinsUp)
                {
                    deviationOfProteinsProDay = ProteinsProDay - DaysDiary.PersonNorm.ProteinsUp;
                }
                else
                    if (ProteinsProDay < DaysDiary.PersonNorm.ProteinsLow)
                {
                    deviationOfProteinsProDay = ProteinsProDay - DaysDiary.PersonNorm.ProteinsLow;
                }
                else
                    deviationOfProteinsProDay = 0;
            }
        }*/
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
        /*
        public double DeviationOfFatsProDay
        {
            get
            {
                return deviationOfFatsProDay;
            }

            set
            {
                if (FatsProDay > DaysDiary.PersonNorm.FatUp)
                {
                    deviationOfFatsProDay = FatsProDay - DaysDiary.PersonNorm.FatUp;
                }
                else
                     if (FatsProDay < DaysDiary.PersonNorm.FatLow)
                {
                    deviationOfFatsProDay = FatsProDay - DaysDiary.PersonNorm.FatLow;
                }
                else
                    deviationOfFatsProDay = 0;
            }
        }*/
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
        }
        /*
        public double DeviationOfCarbohydratesProDay
        {
            get
            {
                return deviationOfCarbohydratesProDay;
            }

            set
            {
                if (CarbohydratesProDay > DaysDiary.PersonNorm.CarbohydratesUp)
                {
                    deviationOfCarbohydratesProDay = CarbohydratesProDay - DaysDiary.PersonNorm.CarbohydratesUp;
                }
                else
                    if (CarbohydratesProDay < DaysDiary.PersonNorm.CarbohydratesLow)
                {
                    deviationOfCarbohydratesProDay = CarbohydratesProDay - DaysDiary.PersonNorm.CarbohydratesLow;
                }
                else
                    deviationOfCarbohydratesProDay = 0;
            }
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
        public double CalloriesProDay
        {
            get
            {
                return calloriesProDay;
            }

            set
            {
                double callory = 0;
                foreach (var item in DaysDiary.DiaryItems)
                {
                    callory += item.Product.Сalories * item.Quantity / 100;
                }
                calloriesProDay = callory;
            }
        }*/
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
        }
        /*
        public double DeviationOfCalloriesProDay
        {
            get
            {
                return deviationOfCalloriesProDay;
            }

            set
            {
                if (CalloriesProDay > DaysDiary.PersonNorm.CaloriesUp)
                {
                    deviationOfCalloriesProDay = CalloriesProDay - DaysDiary.PersonNorm.CaloriesUp;
                }
                else
                    if (CalloriesProDay < DaysDiary.PersonNorm.CaloriesLow)
                {
                    deviationOfCalloriesProDay = CalloriesProDay - DaysDiary.PersonNorm.CaloriesLow;
                }
                else
                    deviationOfCalloriesProDay = 0;
            }
        }*/

    }
}
