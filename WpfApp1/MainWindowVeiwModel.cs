﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using System.Windows.Input;

namespace WpfApp1
{
    class MainWindowVeiwModel : VeiwModelBase
    {

        private Comand comand;

        private Matirial matirial;
        private Tool tool;
        private Handling handling;
        private Calculation calculation;

        public MainWindowVeiwModel()
        {
            matirial = new Matirial("Бронза", 182, 0.12, 0.3, 0.23, 0.7, 0.9);
            tool = new Tool("ВК6", 2.7);
            handling = new Handling("Точение", 55, 1, 0.66, 0);
            calculation = new Calculation(matirial, tool, handling, 4, 1, 95, 100);

            comand = new Comand(ChangeVeiw);

            //System.Windows.Forms.MessageBox.Show(calculation.cuttingSpeed_V.ToString());
            //System.Windows.Forms.MessageBox.Show(calculation.spindleSpeed_N.ToString());
            //System.Windows.Forms.MessageBox.Show(calculation.computerTime_Tm.ToString());
        }

        private void ChangeVeiw(object obj)
        {
            switch (obj.ToString())
            {
                case "Matirial":
                    {
                        System.Windows.Forms.MessageBox.Show("Test");
                    }
                    break;
                default:
                    throw new ArgumentException("неверный параметр выбора окна!");
            }
        }

        public ICommand ChangeVeiwCommand
        {
            get => comand;
        }

        public string CuttingSpeed
        {
            get { return "V = " + calculation.cuttingSpeed_V.ToString() + " м/мин"; }
        }
        public string SpindleSpeed
        {
            get { return "n = " + calculation.spindleSpeed_N.ToString() + " об/мин"; }
        }
        public string ComputerTime
        {
            get { return "Tm = " + calculation.computerTime_Tm.ToString() + " мин"; }
        }
        public string CuttingForce
        {
            get { return "Pz = " + calculation.cuttingForce_Pz.ToString() + " H"; }
        }
    }
}
