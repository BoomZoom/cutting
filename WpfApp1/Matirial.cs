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
    

        private double kiv;


        public Tool( string name ,double Kiv)
        {
            this.kiv = Kiv;
            this.name = name;          
        }

        public double Kiv { get => kiv; }

        public string Name => name;       
    }

    class Handling
    {
        private string name;
      
        //private double S;//подача
       
        private readonly double cp;
        private readonly double xp;
        private readonly double yp;
        private readonly double np;       

        public Handling(string name,double Cp,double Xp,double Yp,double Np)
        {
            this.name = name;
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
    class Matirial
    {
        private readonly string name;
        //private Kv kv;
        private readonly double cv;
        private readonly double xv;
        private readonly double yv;
        private readonly double mv;

        private double kmv;
        private double kpv;

        public Matirial(string name, int Cv, double Xv, double Yv, double Mv, double Kmv, double Kpv)
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

        public double Cv => cv;

        public double Xv => xv;

        public double Yv => yv;

        public double Mv => mv;

        public double Kmv { get => kmv; }
        public double Kpv { get => kpv; }
    }

    class Calculation
    {
        private Matirial matirial;
        private Tool tool;
        private Handling handling;

        private Kv kv;

        private double t;//глубина резания
        private double S;//подача
        private double D;//диаметр заготовки
        private double L;//длина обрабатываемой поверхности

        private double n = 0; //частота вращения шпинделя
        private double V = 0;//скорость резанья
        private double Tm = 0;//Машиное время
        private double Pz = 0;//усилие резания

        int T;//Время стойкости инструмента (мин)

        private Calculation(Matirial matirial, Tool tool,Handling handling)
        {
            this.matirial = matirial;
            this.tool = tool;
            this.handling = handling;

            kv = new Kv(this.matirial.Kmv, this.matirial.Kpv, tool.Kiv);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matirial">Материал</param>
        /// <param name="tool">Инструмент</param>
        /// <param name="handling">Вид обработки</param>
        /// <param name="t">Глубина резания (мм)</param>
        /// <param name="S">Подача (мм)</param>
        /// <param name="D">Диаметр заготовки (мм)</param>
        /// <param name="L">Длина обрабатываемой поверхности (мм)</param>
        /// <param name="T">Среднее значение стойкости (мин)</param>
        public Calculation(Matirial matirial, Tool tool,Handling handling, double t, double S, double D, double L, int T = 60) : this(matirial, tool,handling)
        {
            this.t = t;
            this.S = S;
            this.D = D;
            this.L = L;

            this.T = T;
        }

        /// <summary>
        /// Скорость резания(м/мин)
        /// </summary>
        public double cuttingSpeed_V
        {
            get => V != 0 ? V : V = matirial.Cv / (Pow(T, matirial.Mv) * Pow(t, matirial.Xv) * Pow(S, matirial.Yv) * kv.getKv);
        }
        

        /// <summary>
        /// Частота вашения шпинделя (об/мин)
        /// </summary>
        public double spindleSpeed_N
        {
            get => n != 0 ? n : n = (1000 * cuttingSpeed_V) / (PI * D);
        }

        public double SetTheActualSpeed
        {
            set {  n = value; V = 0; }
        }

        /// <summary>
        /// Машиное время (мин)
        /// </summary>
        public double computerTime_Tm
        {
            get => Tm != 0 ? Tm : Tm = (L + 2) / (spindleSpeed_N * S);
        }

        //TODO сделать сущьность обработка с нужными коэфицыентами для этого метода
        
        public double cuttingForce
        {
            get => Pz!=0? Pz: Pz= 9.8*handling.Cp*Pow(t,handling.Xp)*Pow(S,handling.Yp)*Pow(V,handling.Np)*1;//TODO Сделать коэфициент Кp
        }

    }

}
