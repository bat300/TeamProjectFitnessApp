using FitnessDietApp.Data.Interfaces;

namespace FitnessDietApp.Data
{
    public class DeviationsCalculating : IDeviationsCalculating
    {

        public double DeviationOfProteinsPerDay(double ProteinsProDay, PersonNorm norms)
        {
            if (ProteinsProDay > norms.ProteinsUp)
            {
                return (ProteinsProDay - norms.ProteinsUp);
            }
            else
                    if (ProteinsProDay < norms.ProteinsLow)
            {
                return (ProteinsProDay - norms.ProteinsLow);
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
                return (CarbohydratesProDay - norms.CarbohydratesUp);
            }
            else
                    if (CarbohydratesProDay < norms.CarbohydratesLow)
            {
                return (CarbohydratesProDay - norms.CarbohydratesLow);
            }
            else
                return 0;
        }


        public double DeviationOfCalloriesPerDay(double CalloriesProDay, PersonNorm norms)
        {
            if (CalloriesProDay > norms.CaloriesUp)
            {
                return (CalloriesProDay - norms.CaloriesUp);
            }
            else
                    if (CalloriesProDay < norms.CaloriesLow)
            {
                return (CalloriesProDay - norms.CaloriesLow);
            }
            else
                return 0;
        }

    }
}
