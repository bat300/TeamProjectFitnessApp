using System.Collections.Generic;

namespace FitnessDietApp.Data
{

    public class InfoProDaySummarising
    {

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
        

        public double CalloriesPerDay(List<DiaryItem> diaryItem)
        {
            double callory = 0;
            foreach (var item in diaryItem)
            {
                callory += item.Product.Сalories * item.Quantity / 100;
            }
            return callory;
        }
    }
}
