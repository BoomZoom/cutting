using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core
{
    class Kv
    {
        private double kmv;
        private double kpv;
        private double kiv;
        public Kv(double Kmv, double Kpv, double Kiv)
        {
            this.kmv = Kmv;
            this.kpv = Kpv;
            this.kiv = Kiv;
        }
        public double getKv
        {
            get => kpv * kmv * kiv;
        }

    }
    class Matirial:TechnoligiItemBase
    {
        private readonly double cv;
        private readonly double xv;
        private readonly double yv;
        private readonly double mv;

        private double kmv;
        private double kpv;

        public Matirial(string name, int Cv, double Xv, double Yv, double Mv, double Kmv, double Kpv):base(name)
        {
            cv = Cv;
            xv = Xv;
            yv = Yv;
            mv = Mv;

            kmv = Kmv;
            kpv = Kpv;
        }


        public double Cv => cv;

        public double Xv => xv;

        public double Yv => yv;

        public double Mv => mv;

        public double Kmv { get => kmv; }
        public double Kpv { get => kpv; }
    }

    

}
