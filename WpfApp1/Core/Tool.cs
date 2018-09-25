using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Serializable]
    public class Tool : TechnoligiItemBase
    {
        public Tool()
        {

        }
        public Tool(string name, double Kiv) : base(name)
        {
            this.Kiv = Kiv;
        }

        public double Kiv { get; set; }

    }
}
