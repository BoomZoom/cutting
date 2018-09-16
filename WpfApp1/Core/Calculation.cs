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

        private Calculation(Matirial matirial, Tool tool, Handling handling)
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
        public Calculation(Matirial matirial, Tool tool, Handling handling, double t, double S, double D, double L, int T = 60) : this(matirial, tool, handling)
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
            set { n = value; V = 0; }
        }

        /// <summary>
        /// Машиное время (мин)
        /// </summary>
        public double computerTime_Tm
        {
            get => Tm != 0 ? Tm : Tm = (L + 2) / (spindleSpeed_N * S);
        }

        //TODO сделать сущьность обработка с нужными коэфицыентами для этого метода

        public double cuttingForce_Pz
        {
            get => Pz != 0 ? Pz : Pz = 9.8 * handling.Cp * Pow(t, handling.Xp) * Pow(S, handling.Yp) * Pow(V, handling.Np) * 1;//TODO Сделать коэфициент Кp
        }

    }
}
