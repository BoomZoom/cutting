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
        public MainWindowVeiwModel()
        {
            Matirial matirial = new Matirial("Бронза", 182, 0.12, 0.3, 0.23, 0.7, 0.9);
            Tool tool = new Tool("ВК6", 2.7);
            Handling handling = new Handling("Точение", 55, 1, 0.66, 0);
            Calculation calculation = new Calculation(matirial, tool, handling, 4, 1, 95, 100);

            //System.Windows.Forms.MessageBox.Show(calculation.cuttingSpeed_V.ToString());
            //System.Windows.Forms.MessageBox.Show(calculation.spindleSpeed_N.ToString());
            //System.Windows.Forms.MessageBox.Show(calculation.computerTime_Tm.ToString());
        }
    }
}
