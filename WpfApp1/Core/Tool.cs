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


        private double kiv;


        public Tool(string name, double Kiv)
        {
            this.kiv = Kiv;
            this.name = name;
        }

        public double Kiv { get => kiv; }

        public string Name => name;
    }
}
