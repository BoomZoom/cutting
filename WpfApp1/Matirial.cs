using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core
{
    using static System.Math;
    class Tool
    {
        private readonly string name;

        private int kiv;

        public Tool(int Kiv,string name)
        {
            this.kiv = Kiv;
            this.name = name;
        }

        public int Kiv { get => kiv; }

        public string Name => name;
    }
    class Kv
    {
        private int kmv;
        private int kpv;
        private int kiv;
        public Kv(int Kmv, int Kpv, int Kiv)
        {
            this.kmv = Kmv;
            this.kpv = Kpv;
            this.kiv = Kiv;
        }
        public int getKv
        {
            get => kpv * kmv * kiv;
        }

    }
    class Matirial
    {
        private readonly string name;
        //private Kv kv;
        private readonly int cv;
        private readonly int xv;
        private readonly int yv;
        private readonly int mv;

        private int kmv;
        private int kpv;

        public Matirial(string name,int Cv,int Xv,int Yv,int Mv, int Kmv, int Kpv)
        {
            this.name = name;
            cv = Cv;
            xv = Xv;
            yv = Yv;
            mv = Mv;

            kmv = Kmv;
            kpv = Kpv;
        }

        public string Name => name;

        public int Cv => cv;

        public int Xv => xv;

        public int Yv => yv;

        public int Mv => mv;

        public int Kmv { get => kmv; }
        public int Kpv { get => kpv; }
    }

    class Calculation
    {
        Matirial m;
        Tool tool;

        Kv kv;

        double t;//глубина резания
        double S;//подача

        int T;//Время


        public Calculation(Matirial matirial,Tool tool)
        {
            this.m = matirial;
            this.tool = tool;
        }
        public Calculation(Matirial matirial, Tool tool,double t,double S,int T=60) : this(matirial,tool)
        {
            this.t = t;
            this.S = S;
            this.T = T;
        }


        public double V
        {
            get => m.Cv/(Pow(T,m.Mv))
        }
    }

}
