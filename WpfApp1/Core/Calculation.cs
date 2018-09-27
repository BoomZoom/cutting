using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Math.;
namespace Core
{
    
    class Calculation
    {
        private Material material;                              //Материал
        private Tool tool;                                      //Инструмент
        private Handling handling;                              //Вид обработки

        private Kv kv;                                          //Коэфициент Кv

        private double t_depthOfCut;                            //глубина резания
        private double s_innings;                               //подача
        private double d_billetDiameter;                        //диаметр заготовки
        private double l_lengthOfTheSurfaceToBeTreated;         //длина обрабатываемой поверхности

        private double n_spindleSpeed = 0;                      //частота вращения шпинделя
        private double V_cuttingSpeed = 0;                      //скорость резанья
        private double Tm_MachineTime = 0;                      //Машиное время
        private double Pz_cuttingForce = 0;                     //усилие резания

        private int Time;                                       //Время стойкости инструмента (мин)

        private Calculation(Material material, Tool tool, Handling handling)
        {
            this.material = material;
            this.tool = tool;
            this.handling = handling;

            kv = new Kv(this.material.Kmv, this.material.Kpv, tool.Kiv);
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
        public Calculation(Material matirial, Tool tool, Handling handling, double t, double S, double D, double L, int T = 60) : this(matirial, tool, handling)
        {
            this.t_depthOfCut = t;
            this.s_innings = S;
            this.d_billetDiameter = D;
            this.l_lengthOfTheSurfaceToBeTreated = L;

            this.Time = T;
        }

        /// <summary>
        /// Скорость резания(м/мин)
        /// </summary>
        public double CuttingSpeed_V
        {
            get { return V_cuttingSpeed = material.Cv / (System.Math.Pow(Time, material.Mv) * System.Math.Pow(t_depthOfCut, material.Xv) * System.Math.Pow(s_innings, material.Yv) * kv.getKv); }
        }


        /// <summary>
        /// Частота вашения шпинделя (об/мин)
        /// </summary>
        public double SpindleSpeed_N
        {
            get { return n_spindleSpeed = (1000 * CuttingSpeed_V) / (System.Math.PI * d_billetDiameter); }
        }
      
        /// <summary>
        /// мощность
        /// </summary>
        public double Power_Pz
        {
            get {return CuttingSpeed_V / 60 * CuttingForce_Pz;}
        }
               public double SetTheActualSpeed
        {
            set { n_spindleSpeed = value; }
        }

        /// <summary>
        /// Машиное время (мин)
        /// </summary>
        public double ComputerTime_Tm
        {
            get {return Tm_MachineTime = (l_lengthOfTheSurfaceToBeTreated + 2) / (SpindleSpeed_N * s_innings);}
        }
        /// <summary>
        /// Сила резанья (H)
        /// </summary>
        public double CuttingForce_Pz
        {
            get { return Pz_cuttingForce = 9.8 * handling.Cp * 
                System.Math.Pow(t_depthOfCut, handling.Xp) * 
                System.Math.Pow(s_innings, handling.Yp) * 
                System.Math.Pow(V_cuttingSpeed, handling.Np) * 1; }//TODO Сделать коэфициент Кp
        }
        public double T_DepthOfCut { get {return t_depthOfCut; }set { t_depthOfCut = value;} }
        public double S_Innings { get {return s_innings;} set { s_innings = value;} }
        public double D_BilletDiameter { get {return d_billetDiameter;} set { d_billetDiameter = value;} }
        public double L_LengthOfTheSurfaceToBeTreated { get {return l_lengthOfTheSurfaceToBeTreated;} set { l_lengthOfTheSurfaceToBeTreated = value;} }

        internal Material Material { get {return material;} set { material = value; kv.Kmv = value.Kmv; kv.Kpv = value.Kpv; } }
        internal Tool Tool { get {return tool;} set { tool = value; kv.Kiv = value.Kiv; } }
        internal Handling Handling { get { return handling; } set { handling = value; } }
    }
}
