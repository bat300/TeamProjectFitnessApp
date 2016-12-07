using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    public delegate void Recomendation(string Message);
    class Analysing
    {
        public event Recomendation RecomendationMessage;
        public void Recomendations()//продумать рекомендации и выводы!
        {
            RecomendationMessage("Сообщение");
        }
    }
}
