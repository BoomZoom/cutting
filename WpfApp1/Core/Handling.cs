using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Serializable]
   public class Handling:TechnoligiItemBase
    {
        //Это не переводится, честно я искал это показатели степени для конкретных (расчетных)
        //условийобработки для каждой из составляющих силы резания

        //private readonly double cp;
        //private readonly double xp;
        //private readonly double yp;
        //private readonly double np;

        public Handling()
        {

        }

        public Handling(string name, double Cp, double Xp, double Yp, double Np):base(name)
        {
          
            this.Cp = Cp;
            this.Xp = Xp;
            this.Yp = Yp;
            this.Np = Np;
        }

        public double Cp { get; set; }
        public double Xp { get; set; }

        public double Yp { get; set; }

        public double Np { get; set; }

    }
}
