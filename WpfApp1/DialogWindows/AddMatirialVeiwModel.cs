using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Core;

namespace WpfApp1.DialogWindows
{
    class AddMatirialVeiwModel:VeiwModelBase
    {
        private Comand comand;
        Action<object> action;
        

        private string name;
        private int cv;
        private double xv;
        private double yv;
        private double mv;

        private double kmv;
        private double kpv;

        public AddMatirialVeiwModel(Action<object> action)
        {
            this.action = action;
            comand = new Comand(CreateMatiriall);
        }
        private void CreateMatiriall(object NotUse)
        {
            try
            {
                Matirial matirial = new Matirial(name, cv, xv, yv, mv, kmv, kpv);
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
