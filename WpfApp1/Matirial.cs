using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
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
        //private Kv kv;
        private int cv;
        private int xv;
        private int yv;
        private int mv;

    }
}
