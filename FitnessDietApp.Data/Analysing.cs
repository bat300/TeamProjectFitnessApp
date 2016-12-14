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
