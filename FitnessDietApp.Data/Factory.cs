using FitnessDietApp.Data.Interfaces;

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
        private IDeviationsCalculating _deviationsCalculating;
        private IAnalysing _analysing;


        public ICalculateNorm GetCalculateNorm()
        {
            if (_calculateNorm == null)
                _calculateNorm = new CalculateNorm();
            return _calculateNorm;
        }


        public IDeviationsCalculating GetDeviationsCalculating()
        {
            if (_deviationsCalculating == null)
                _deviationsCalculating = new DeviationsCalculating();
            return _deviationsCalculating;
        }
        

        public IAnalysing GetIAnalysing()
        {
            if (_analysing == null)
                _analysing = new Analysing();
            return _analysing;
        }

    }
}
