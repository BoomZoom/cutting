using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using System.Windows.Input;
using WpfApp1.DialogWindows;

namespace WpfApp1
{
    class MainWindowVeiwModel : VeiwModelBase
    {
        ObservableCollection<Matirial> matirials;

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

            matirials = new ObservableCollection<Matirial>() { matirial };
        }

        private void qwert(object obj)
        {
            System.Windows.Forms.MessageBox.Show("MainWindow");
            if (obj is Matirial)
            {
                Matirial matirial = (Matirial)obj;
                System.Windows.Forms.MessageBox.Show($" cv= {matirial.Cv} , xv={matirial.Xv}, yv={matirial.Yv},\n mv={matirial.Mv}, kmv={matirial.Kmv}, kpv={matirial.Kpv} ");
                Matirials.Add(matirial);
            }
        }

        private void ChangeVeiw(object obj)
        {
            switch (obj.ToString())
            {
                case "Matirial":
                    {
                        AddMatirial addMatirial = new AddMatirial(qwert);
                        addMatirial.ShowDialog();
                    }
                    break;
                case "Tool":
                    {
                        AddTool addTool = new AddTool();
                        addTool.ShowDialog();
                    }
                    break;
                case "Handling":
                    {
                        AddHandling addHandling = new AddHandling();
                        addHandling.ShowDialog();
                    }
                    break;
                default:
                    throw new ArgumentException("неверный параметр выбора окна!");
            }
        }
        private void UpdateAnswerAllPropertiesChanged()
        {
            OnPropertyChanged("CuttingSpeed");
            OnPropertyChanged("SpindleSpeed");
            OnPropertyChanged("ComputerTime");
            OnPropertyChanged("CuttingForce");
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

        public double T_DepthOfCut
        {
            get => calculation.T_DepthOfCut;
            set
            {
                calculation.T_DepthOfCut = value;               
                UpdateAnswerAllPropertiesChanged();
            }
        }
        public double S_Innings
        {
            get => calculation.S_Innings;
            set
            {
                calculation.S_Innings = value;
                UpdateAnswerAllPropertiesChanged();
            }
        }
        public double L_LengthOfTheSurfaceToBeTreated
        {
            get => calculation.L_LengthOfTheSurfaceToBeTreated;
            set {
                calculation.L_LengthOfTheSurfaceToBeTreated = value;
                UpdateAnswerAllPropertiesChanged();
            }
        }      
        public double D_BilletDiameter
        {
            get => calculation.D_BilletDiameter;
            set {
                calculation.D_BilletDiameter = value;
                UpdateAnswerAllPropertiesChanged();
            }
        }

        public ObservableCollection<Matirial> Matirials { get => matirials; set => matirials = value; }
    }
}
