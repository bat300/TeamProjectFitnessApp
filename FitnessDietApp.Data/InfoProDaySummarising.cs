using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    public class InfoProDaySummarising
    {
        private double proteinsProDay;
        private double fatsProDay;
        private double carbohydratesProDay;
        private double calloriesProDay;
        private double deviationOfProteinsProDay;
        private double deviationOfFatsProDay;
        private double deviationOfCarbohydratesProDay;
        private double deviationOfCalloriesProDay;

        public Diary DaysDiary { get; set; }

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
                proteinsProDay = fat;
            }
        }

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
                proteinsProDay = carbohydrate;
            }
        }

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
        }

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
        }

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
        }

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
                proteinsProDay = callory;
            }
        }

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
        }
    }
}
