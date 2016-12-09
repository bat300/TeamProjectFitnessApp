using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    public delegate void Recomendation(string Message);
    public class Analysing
    {
        public event Recomendation RecomendationMessage;
        Factory factory;
        public void Recomendations(DateTime date)//продумать рекомендации и выводы!
        {
            double AveragePersentageOfFat=0;
            double AveragePersentageOfProteins=0;
            double AveragePersentageOfCarbohydrates=0;
            double AveragePersentageOfCallories = 0;
            int NumberOfDays = 0;
            using (var cont = factory.GetContext())
            {
                foreach (var item in cont.InfoProDaySummarisings)
                {
                    if (item.DaysDiary.Date>=date)
                    {
                        if (item.DeviationOfCarbohydratesProDay>0)
                        {
                            AveragePersentageOfCarbohydrates += item.DeviationOfCarbohydratesProDay / item.DaysDiary.PersonNorm.CarbohydratesUp;
                        }
                        else
                        {
                            AveragePersentageOfCarbohydrates += item.DeviationOfCarbohydratesProDay / item.DaysDiary.PersonNorm.CarbohydratesLow;
                        }
                        if (item.DeviationOfFatsProDay > 0)
                        {
                            AveragePersentageOfFat += item.DeviationOfFatsProDay / item.DaysDiary.PersonNorm.FatUp;
                        }
                        else
                        {
                            AveragePersentageOfFat += item.DeviationOfFatsProDay / item.DaysDiary.PersonNorm.FatLow;
                        }
                        if (item.DeviationOfProteinsProDay > 0)
                        {
                            AveragePersentageOfProteins += item.DeviationOfProteinsProDay / item.DaysDiary.PersonNorm.ProteinsUp;
                        }
                        else
                        {
                            AveragePersentageOfProteins += item.DeviationOfProteinsProDay / item.DaysDiary.PersonNorm.ProteinsLow;
                        }
                        if (item.DeviationOfCalloriesProDay > 0)
                        {
                            AveragePersentageOfCallories += item.DeviationOfCalloriesProDay / item.DaysDiary.PersonNorm.CaloriesUp;
                        }
                        else
                        {
                            AveragePersentageOfCallories += item.DeviationOfCalloriesProDay / item.DaysDiary.PersonNorm.CaloriesLow;
                        }
                        NumberOfDays += 1;
                    }
                }
                AveragePersentageOfCallories = AveragePersentageOfCallories / NumberOfDays;
                AveragePersentageOfCarbohydrates = AveragePersentageOfCarbohydrates / NumberOfDays;
                AveragePersentageOfFat = AveragePersentageOfFat / NumberOfDays;
                AveragePersentageOfProteins = AveragePersentageOfProteins / NumberOfDays;
                if ((AveragePersentageOfProteins>0)&&(AveragePersentageOfFat>0)&&(AveragePersentageOfCarbohydrates>0))//Доделать!
                {
                    var Message = String.Format("");
                    RecomendationMessage(Message);
                }
                else
                {
                    RecomendationMessage("Сообщение");
                }
            }
        }
    }
}
