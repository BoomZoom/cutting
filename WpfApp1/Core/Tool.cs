using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Serializable]
    class Tool : TechnoligiItemBase
    {
        private double kiv;

        public Tool(string name, double Kiv) : base(name)
        {
            this.kiv = Kiv;
        }

        public double Kiv { get => kiv; }

    }
}
