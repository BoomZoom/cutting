using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace WpfApp1
{
    class MainWindowVeiwModel
    {

        Matirial matirial;
        Tool tool;
        Handling handling;
        Calculation calculation;

        public MainWindowVeiwModel()
        {
            matirial = new Matirial("Бронза", 182, 0.12, 0.3, 0.23, 0.7, 0.9);
            tool = new Tool("ВК6", 2.7);
            handling = new Handling("Точение", 55, 1, 0.66, 0);
            calculation = new Calculation(matirial, tool, handling, 4, 1, 95, 100);

            //System.Windows.Forms.MessageBox.Show(calculation.cuttingSpeed_V.ToString());
            //System.Windows.Forms.MessageBox.Show(calculation.spindleSpeed_N.ToString());
            //System.Windows.Forms.MessageBox.Show(calculation.computerTime_Tm.ToString());
        }

        public string CuttingSpeed
        {
            get { return "V = " + calculation.cuttingSpeed_V.ToString()+" м/мин"; }
        }
        public string SpindleSpeed
        {
            get { return "n = " + calculation.spindleSpeed_N.ToString()+" об/мин"; }
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
