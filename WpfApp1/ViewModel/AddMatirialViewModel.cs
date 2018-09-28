using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Core;


namespace WpfApp1
{
    class AddMatirialViewModel : ViewModelBase
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

        public AddMatirialViewModel(Window window, Action<object> action)
        {
            this.action = action;
            comand = new Command(CreateMatiriall);
            this.window = window;
        }
        private void CreateMatiriall(object NotUse)
        {
            try
            {
                Material matirial = new Material(name, cv, xv, yv, mv, kmv, kpv);
                action(matirial);
                window.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        public ICommand AddMatirial
        {
            get { return comand; }
        }
        public string Name { get { return name; } set { name = value; } }
        public int Cv { get { return cv; } set { cv = value; } }
        public double Xv { get { return xv; } set { xv = value; } }
        public double Yv { get { return yv; } set { yv = value; } }
        public double Mv { get { return mv; } set { mv = value; } }
        public double Kmv { get { return kmv; } set { kmv = value; } }
        public double Kpv { get { return kpv; } set { kpv = value; } }
    }
}
