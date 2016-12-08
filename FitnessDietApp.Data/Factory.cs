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

        private Products _products;
        private PersonNorm _personNorm;
        private PersonInfo _personInfo;
        private InfoProDaySummarising _infoProDaySummarising;
        private DiaryItem _diaryItem;
        private Diary _diary;
        private Context _context;
        private CalculateNorm _calculateNorm;
        private Analysing _analysing;

        public Products GetProducts()
        {
            if (_products == null)
                _products = new Products();
            return _products;
        }

        public PersonNorm GetPersonNorm()
        {
            if (_personNorm == null)
                _personNorm = new PersonNorm();
            return _personNorm;
        }

        public PersonInfo GetPersonInfo()
        {
            if (_personInfo == null)
                _personInfo = new PersonInfo();
            return _personInfo;
        }

        public InfoProDaySummarising GetInfoProDaySummarising()
        {
            if (_infoProDaySummarising == null)
                _infoProDaySummarising = new InfoProDaySummarising();
            return _infoProDaySummarising;
        }

        public DiaryItem GetDiaryItem()
        {
            if (_diaryItem == null)
                _diaryItem = new DiaryItem();
            return _diaryItem;
        }

        public Diary GetDiary()
        {
            if (_diary == null)
                _diary = new Diary();
            return _diary;
        }

        public Context GetContext()
        {
            if (_context == null)
                _context = new Context();
            return _context;
        }

        public Analysing GetAnalysing()
        {
            if (_analysing == null)
                _analysing = new Analysing();
            return _analysing;
        }  

    }
}
