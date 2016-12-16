using FitnessDietApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data
{
    public class Factory
    {
        private Factory() { }

        static Factory _default;

        public static Factory Default
        {
            get
            {
                if (_default == null)
                    _default = new Factory();
                return _default;
            }
        }

        private ICalculateNorm _calculateNorm;
        private IDeviationsCalculating _ideviationsCalculating;  
                  
        private Analysing _analysing;
        
        public ICalculateNorm GetCalculateNorm()
        {
            if (_calculateNorm == null)
                _calculateNorm = new CalculateNorm();
            return _calculateNorm;
        }       
               
                
        public IDeviationsCalculating GetDeviationsCalculating()
        {
            if (_ideviationsCalculating == null)
                _ideviationsCalculating = new DeviationsCalculating();
            return _ideviationsCalculating;
        }       

        public Analysing GetAnalysing()
        {
            if (_analysing == null)
                _analysing = new Analysing();
            return _analysing;
        }  

    }
}
