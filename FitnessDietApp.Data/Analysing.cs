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
        public void Recomendations(DateTime date)
        {
            double AveragePersentageOfFat=0;
            double AveragePersentageOfProteins=0;
            double AveragePersentageOfCarbohydrates=0;
            double AveragePersentageOfCallories = 0;
            int NumberOfDays = 0;
            InfoProDaySummarising inf = new InfoProDaySummarising();
            using (var cont = factory.GetContext())
            {
                foreach (var item in cont.Diary)
                    {
                    double CarbohydratesProDay = inf.CarbohydratesPerDay(item.DiaryItems);
                    double DeviationOfCarbohydratesProDay = inf.DeviationOfCarbohydratesPerDay(CarbohydratesProDay, item.PersonNorm);
                    double FatsProDay = inf.FatsPerDay(item.DiaryItems);
                    double DeviationOfFatsProDay = inf.DeviationOfFatsPerDay(FatsProDay, item.PersonNorm);
                    double ProteinsProDay = inf.ProteinsPerDay(item.DiaryItems);
                    double DeviationOfProteinsProDay = inf.DeviationOfProteinsPerDay(ProteinsProDay, item.PersonNorm);
                    double CalloriesProDay = inf.CalloriesPerDay(item.DiaryItems);
                    double DeviationOfCalloriesProDay = inf.DeviationOfCalloriesPerDay(CalloriesProDay,item.PersonNorm);
                    if (item.Date>=date)
                    {
                        if (DeviationOfCarbohydratesProDay>0)
                        {
                            AveragePersentageOfCarbohydrates += DeviationOfCarbohydratesProDay / item.PersonNorm.CarbohydratesUp;
                        }
                        else
                        {
                            AveragePersentageOfCarbohydrates += DeviationOfCarbohydratesProDay / item.PersonNorm.CarbohydratesLow;
                        }
                        if (DeviationOfFatsProDay > 0)
                        {
                            AveragePersentageOfFat += DeviationOfFatsProDay / item.PersonNorm.FatUp;
                        }
                        else
                        {
                            AveragePersentageOfFat += DeviationOfFatsProDay / item.PersonNorm.FatLow;
                        }
                        if (DeviationOfProteinsProDay > 0)
                        {
                            AveragePersentageOfProteins += DeviationOfProteinsProDay / item.PersonNorm.ProteinsUp;
                        }
                        else
                        {
                            AveragePersentageOfProteins += DeviationOfProteinsProDay / item.PersonNorm.ProteinsLow;
                        }
                        if (DeviationOfCalloriesProDay > 0)
                        {
                            AveragePersentageOfCallories += DeviationOfCalloriesProDay / item.PersonNorm.CaloriesUp;
                        }
                        else
                        {
                            AveragePersentageOfCallories += DeviationOfCalloriesProDay / item.PersonNorm.CaloriesLow;
                        }
                        NumberOfDays += 1;
                    }
                }
                AveragePersentageOfCallories = AveragePersentageOfCallories / NumberOfDays;
                AveragePersentageOfCarbohydrates = AveragePersentageOfCarbohydrates / NumberOfDays;
                AveragePersentageOfFat = AveragePersentageOfFat / NumberOfDays;
                AveragePersentageOfProteins = AveragePersentageOfProteins / NumberOfDays;
                StringBuilder Message = new StringBuilder();
                Message.Append(String.Format("Средние отклонения от нормы БЖУ: Белки {0}%, Жиры {1}%, Углеводы {2} %, Каллории {3}%. /n",AveragePersentageOfProteins,AveragePersentageOfFat,AveragePersentageOfCarbohydrates, AveragePersentageOfCallories));
                if ((AveragePersentageOfProteins>0)&&(AveragePersentageOfFat>0)&&(AveragePersentageOfCarbohydrates>0))//Доделать!
                {

                     Message.Append("Рекомендуется уменьшить количество потребляемой пищи.");
                    RecomendationMessage(Message.ToString());
                }
                else
                {
                    if ((AveragePersentageOfProteins < 0) && (AveragePersentageOfFat < 0) && (AveragePersentageOfCarbohydrates < 0))
                    {
                         Message.Append("Рекомендуется увеличить количество потребляемой пищи.");
                        RecomendationMessage(Message.ToString());
                    }
                    
                    else
                        if ((AveragePersentageOfProteins == 0) && (AveragePersentageOfFat == 0) && (AveragePersentageOfCarbohydrates == 0))
                    {
                         Message.Append("Так держать! Вы на пути к поставленной цели!");
                        RecomendationMessage(Message.ToString());
                    }
                    else
                        if ((AveragePersentageOfProteins == 0) || (AveragePersentageOfFat == 0) || (AveragePersentageOfCarbohydrates == 0))
                    {
                         Message.Append("Вы движетесь в правильном направлении! Рекомендуется скорректировать потребление ");
                        if (AveragePersentageOfCarbohydrates!=0)
                        {
                            Message.Append( "углеводов,");
                        }
                        if (AveragePersentageOfFat!=0)
                        {
                            Message.Append( " жиров,");
                        }
                        if (AveragePersentageOfProteins!=0)
                        {
                            Message.Append( " углеводов,");
                        }
                        Message.Remove(Message.Length, 1);
                        Message.Append( ".");
                        RecomendationMessage(Message.ToString());
                    }
                    else
                    {
                        Message.Append("Рекомендуется скорректировать весь рацион в соответствии с нормами КБЖУ");
                        RecomendationMessage(Message.ToString());
                    } 
                }
            }
        }
    }
}
