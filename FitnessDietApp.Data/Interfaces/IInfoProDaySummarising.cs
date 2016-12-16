using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data.Interfaces
{
    public interface IInfoProDaySummarising
    {
        double ProteinsPerDay (List<DiaryItem> diaryItem);
        double FatsPerDay(List<DiaryItem> diaryItem);
        double CarbohydratesPerDay(List<DiaryItem> diaryItems);
        double CalloriesPerDay(List<DiaryItem> diaryItem);

        double DeviationOfProteinsPerDay(double ProteinsProDay, PersonNorm norms);
        double DeviationOfFatsPerDay(double FatsProDay, PersonNorm norms);
        double DeviationOfCarbohydratesPerDay(double CarbohydratesProDay, PersonNorm norms);        
        double DeviationOfCalloriesPerDay(double CalloriesProDay, PersonNorm norms);
    }
}
