using System;

namespace FitnessDietApp.Data.Interfaces
{
    public interface IAnalysing
    {
        void Recomendations(DateTime date);
        event Recomendation RecomendationMessage;
    }
}
