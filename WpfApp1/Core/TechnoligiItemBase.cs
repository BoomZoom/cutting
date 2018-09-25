using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Serializable]
    public class TechnoligiItemBase
    {
        public TechnoligiItemBase()
        {

        }
        public TechnoligiItemBase(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
