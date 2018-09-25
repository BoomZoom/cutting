using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Core;

namespace WpfApp1
{
    class AddMatirialViewModel:ViewModelBase
    {
        private Command comand;
        Action<object> action;
        

        private string name;
        private int cv;
        private double xv;
        private double yv;
        private double mv;

        private double kmv;
        private double kpv;

        public AddMatirialViewModel(Action<object> action)
        {
            this.action = action;
            comand = new Command(CreateMatiriall);
        }
        private void CreateMatiriall(object NotUse)
        {
            try
            {
                Material matirial = new Material(name, cv, xv, yv, mv, kmv, kpv);
                action(matirial);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        public ICommand AddMatirial
        {
            get => comand;
        }
        public string Name { get => name; set { name = value; } }
        public int Cv { get => cv; set => cv = value; }
        public double Xv { get => xv; set => xv = value; }
        public double Yv { get => yv; set => yv = value; }
        public double Mv { get => mv; set => mv = value; }
        public double Kmv { get => kmv; set => kmv = value; }
        public double Kpv { get => kpv; set => kpv = value; }
    }
}
