
namespace FitnessDietApp.Data.Interfaces
{
    public interface IDeviationsCalculating
    {
        double DeviationOfProteinsPerDay(double ProteinsProDay, PersonNorm norms);
        double DeviationOfFatsPerDay(double FatsProDay, PersonNorm norms);
        double DeviationOfCarbohydratesPerDay(double CarbohydratesProDay, PersonNorm norms);        
        double DeviationOfCalloriesPerDay(double CalloriesProDay, PersonNorm norms);
    }
}
