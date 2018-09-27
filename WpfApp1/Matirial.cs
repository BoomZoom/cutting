using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M = System.Math;

namespace Core
{
   
    class Tool
    {
        private readonly string name;
    

        private double kiv;


        public Tool( string name ,double Kiv)
        {
            this.kiv = Kiv;
            this.name = name;          
        }

        public double Kiv { get { return kiv;} }

        public string Name {get{ return name; }}
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

        public double Cp { get {return cp;}}

        public double Xp {  get {return xp;}}

        public double Yp {  get {return yp;}}

        public double Np {  get {return np;}}

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
            get {return kpv * kmv * kiv;}
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

        public string Name { get { return  name;}}

        public double Cv { get { return cv;}}

        public double Xv { get { return xv;}}

        public double Yv { get { return yv;}}

        public double Mv { get { return mv;}}

        public double Kmv { get {  return kmv; }}
        public double Kpv { get { return kpv; }}
    }

    class Calculation
    {
        private Matirial matirial;//Материал
        private Tool tool;//Инструмент
        private Handling handling;//Вид обработки

        private Kv kv;//Коэфициент Кv

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
        /// Конструктор
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
            get  {return  V = matirial.Cv / (System.Math.Pow(T, matirial.Mv) * System.Math.Pow(t, matirial.Xv) * System.Math.Pow(S, matirial.Yv) * kv.getKv);}
        }
        

        /// <summary>
        /// Частота вашения шпинделя (об/мин)
        /// </summary>
        public double spindleSpeed_N
        {
            get { return  n = (1000 * cuttingSpeed_V) / (System.Math.PI * D); }
        }

        public double SetTheActualSpeed
        {
            set { n = value; V = 0; }
        }

        /// <summary>
        /// Машиное время (мин)
        /// </summary>
        public double computerTime_Tm
        {
            get {return  Tm = (L + 2) / (spindleSpeed_N * S);}
        }

        //TODO сделать сущьность обработка с нужными коэфицыентами для этого метода
        
        public double cuttingForce_Pz
        {
            get {return  Pz= 9.8*handling.Cp*System.Math.Pow(t,handling.Xp)*System.Math.Pow(S,handling.Yp)*System.Math.Pow(V,handling.Np)*1;}//TODO Сделать коэфициент Кp
        }

        public double SetT
        {
            set { t = value; }
        }
        public double SetS
        {
            set { S = value; } 
        }
    }

}
