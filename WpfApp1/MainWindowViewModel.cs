using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using System.Windows.Input;
using WpfApp1.DialogWindows;
using System.Windows.Controls;

namespace WpfApp1
{
    class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Material> materials;
        private ObservableCollection<Tool> tools;
        private ObservableCollection<Handling> handlings;

        private Command comand;

        private Material matirial;
        private Tool tool;
        private Handling handling;
        private Calculation calculation;

        public MainWindowViewModel()
        {
            matirial = new Material("Бронза", 182, 0.12, 0.3, 0.23, 0.7, 0.9);
            tool = new Tool("ВК6", 2.7);
            handling = new Handling("Точение", 55, 1, 0.66, 0);
            calculation = new Calculation(matirial, tool, handling, 4, 1, 95, 100);

            comand = new Command(ChangeVeiw);

            materials = new ObservableCollection<Material>(Serialization<Material>.Deserialization());
            tools = new ObservableCollection<Tool>(Serialization<Tool>.Deserialization());
            handlings = new ObservableCollection<Handling> ( Serialization<Handling>.Deserialization());
        }


        public void OnWindowClosing(object sender, EventArgs e)
        {
            Serialization<Material>.Save(materials);
            Serialization<Tool>.Save(tools);
            Serialization<Handling>.Save(handlings);
        }


        private void AddItemListDialogDiligate(object obj)
        {
            if (obj is Material)
            {
                Materials.Add((Material)obj);
            }
            if (obj is Tool)
                Tools.Add((Tool)obj);
            if (obj is Handling)
                Handlings.Add((Handling)obj);

            System.Windows.Forms.MessageBox.Show(obj.ToString());
        }

        private void ChangeVeiw(object obj)
        {
            switch (obj.ToString())
            {
                case "Matirial":
                    {
                        AddMatirial addMatirial = new AddMatirial(AddItemListDialogDiligate);
                        addMatirial.ShowDialog();
                    }
                    break;
                case "Tool":
                    {
                        AddTool addTool = new AddTool(AddItemListDialogDiligate);
                        addTool.ShowDialog();
                    }
                    break;
                case "Handling":
                    {
                        AddHandling addHandling = new AddHandling(AddItemListDialogDiligate);
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
            get { return "V = " + calculation.CuttingSpeed_V.ToString() + " м/мин"; }
        }
        public string SpindleSpeed
        {
            get { return "n = " + calculation.SpindleSpeed_N.ToString() + " об/мин"; }
        }
        public string ComputerTime
        {
            get { return "Tm = " + calculation.ComputerTime_Tm.ToString() + " мин"; }
        }
        public string CuttingForce
        {
            get { return "Pz = " + calculation.CuttingForce_Pz.ToString() + " H"; }
        }
        public string Power
        {
            get { return "Nz = " + calculation.Power_Pz.ToString() + " Вт"; }
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
            set
            {
                calculation.L_LengthOfTheSurfaceToBeTreated = value;
                UpdateAnswerAllPropertiesChanged();
            }
        }
        public double D_BilletDiameter
        {
            get => calculation.D_BilletDiameter;
            set
            {
                calculation.D_BilletDiameter = value;
                UpdateAnswerAllPropertiesChanged();
            }
        }

        public ObservableCollection<Material> Materials { get => materials; set => materials = value; }
        public ObservableCollection<Tool> Tools { get => tools; set => tools = value; }
        public ObservableCollection<Handling> Handlings { get => handlings; set => handlings = value; }

        public Material MySelectedItemMatirial
        {
            get { return calculation.Material; }
            set
            {
                calculation.Material = value;
                UpdateAnswerAllPropertiesChanged();
            }
        }

        public Tool MySelectedItemTool
        {
            get { return calculation.Tool; }
            set
            {
                calculation.Tool = value;
                UpdateAnswerAllPropertiesChanged();
            }
        }
        public Handling MySelectedItemHandling
        {
            get { return calculation.Handling; }
            set
            {
                calculation.Handling = value;
                UpdateAnswerAllPropertiesChanged();
            }
        }
    }
}
