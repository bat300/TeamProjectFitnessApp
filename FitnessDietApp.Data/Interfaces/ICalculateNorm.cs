using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDietApp.Data.Interfaces
{
    public interface ICalculateNorm
    {
        void CalculateNorms (PersonInfo personInfo, PersonNorm personNorm);
    }
}
