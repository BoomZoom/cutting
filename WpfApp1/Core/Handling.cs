using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    class Handling:TechnoligiItemBase
    { private string name;

        //private double S;//подача

        private readonly double cp;
        private readonly double xp;
        private readonly double yp;
        private readonly double np;

        public Handling(string name, double Cp, double Xp, double Yp, double Np):base(name)
        {
          
            this.cp = Cp;
            this.xp = Xp;
            this.yp = Yp;
            this.np = Np;
        }

        public double Cp => cp;

        public double Xp => xp;

        public double Yp => yp;

        public double Np => np;

    }
}
