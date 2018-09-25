using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Core;

namespace WpfApp1
{
    class AddHandingViewModel : ViewModelBase
    {
        private string name;
        private double cp;
        private double xp;
        private double yp;
        private double np;

        private Command comand;
        //TODO убрать object из action во всех класах этого типа
        private Action<object> action;
        public AddHandingViewModel(Action<object> action)
        {
            this.action = action;
            comand = new Command(CreateHanding);
        }

        public ICommand AddHanding => comand;

        public string Name { get => name; set => name = value; }
        public double Cp { get => cp; set => cp = value; }
        public double Xp { get => xp; set => xp = value; }
        public double Yp { get => yp; set => yp = value; }
        public double Np { get => np; set => np = value; }

        private void CreateHanding(object NotUse)
        {
            action(new Handling(Name, cp, xp, yp, np));
        }
    }
}
