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
        public double Kmv { get => kmv; set => kmv = value; }
        public double Kpv { get => kpv; set => kpv = value; }
        public double Kiv { get => kiv; set => kiv = value; }
    }
    [Serializable]
    public class Material : TechnoligiItemBase
    {
        // к сожалению это коэфициенты 
        //private double cv;
        //private double xv;
        //private double yv;
        //private double mv;

        //private double kmv;
        //private double kpv;

        public double Cv { get; set; }
        public double Xv { get; set; }
        public double Yv { get; set; }
        public double Mv { get; set; }

        public double Kmv { get; set; }
        public double Kpv { get; set; }

        public Material(string name, int Cv, double Xv, double Yv, double Mv, double Kmv, double Kpv) : base(name)
        {
            this.Cv = Cv;
            this.Xv = Xv;
            this.Yv = Yv;
            this.Mv = Mv;

            this.Kmv = Kmv;
            this.Kpv = Kpv;
        }

        public Material()
        {

        }

        //public double Cv => cv;

        //public double Xv => xv;

        //public double Yv => yv;

        //public double Mv => mv;

        //public double Kmv { get => kmv; }
        //public double Kpv { get => kpv; }


    }
}
