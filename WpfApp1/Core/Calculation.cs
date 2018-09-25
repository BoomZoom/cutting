using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    using static System.Math;
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
            get => V_cuttingSpeed = material.Cv / (Pow(Time, material.Mv) * Pow(t_depthOfCut, material.Xv) * Pow(s_innings, material.Yv) * kv.getKv);
        }


        /// <summary>
        /// Частота вашения шпинделя (об/мин)
        /// </summary>
        public double SpindleSpeed_N
        {
            get => n_spindleSpeed = (1000 * CuttingSpeed_V) / (PI * d_billetDiameter);
        }
      
        /// <summary>
        /// мощность
        /// </summary>
        public double Power_Pz
        {
            get => CuttingSpeed_V / 60 * CuttingForce_Pz;
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
            get => Tm_MachineTime = (l_lengthOfTheSurfaceToBeTreated + 2) / (SpindleSpeed_N * s_innings);
        }
        /// <summary>
        /// Сила резанья (H)
        /// </summary>
        public double CuttingForce_Pz
        {
            get => Pz_cuttingForce = 9.8 * handling.Cp * Pow(t_depthOfCut, handling.Xp) * Pow(s_innings, handling.Yp) * Pow(V_cuttingSpeed, handling.Np) * 1;//TODO Сделать коэфициент Кp
        }
        public double T_DepthOfCut { get => t_depthOfCut; set => t_depthOfCut = value; }
        public double S_Innings { get => s_innings; set => s_innings = value; }
        public double D_BilletDiameter { get => d_billetDiameter; set => d_billetDiameter = value; }
        public double L_LengthOfTheSurfaceToBeTreated { get => l_lengthOfTheSurfaceToBeTreated; set => l_lengthOfTheSurfaceToBeTreated = value; }

        internal Material Material { get => material; set { material = value; kv.Kmv = value.Kmv; kv.Kpv = value.Kpv; } }
        internal Tool Tool { get => tool; set { tool = value; kv.Kiv = value.Kiv; } }
        internal Handling Handling { get => handling; set => handling = value; }
    }
}
