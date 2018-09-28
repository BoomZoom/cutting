using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using Core;
using System.Windows.Input;
using WpfApp1.DialogWindows;
using System.Windows.Controls;
using System.Windows;



namespace WpfApp1
{
    class MainWindowViewModel : ViewModelBase
    {
        #region Private
        #region Field
        private ObservableCollection<Material> materials;
        private ObservableCollection<Tool> tools;
        private ObservableCollection<Handling> handlings;

        private Command commandPlus;
        private Command commandNewValue;

        //  private double spindleSpeed;

        private Material matirial;
        private Tool tool;
        private Handling handling;
        private Calculation calculation;

        private Thickness panelOutlet;
        #endregion Field
        #region Metods
        private void NewValue(object obj)
        {
            calculation.SpindleSpeed_N = SpindleSpeedReal;
            UpdateAnswerAllPropertiesChanged();
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
        #endregion Metods
        #endregion Private
        #region Public
        #region ctor
        public MainWindowViewModel()
        {
            matirial = new Material("Бронза", 182, 0.12, 0.3, 0.23, 0.7, 0.9);
            tool = new Tool("ВК6", 2.7);
            handling = new Handling("Точение", 55, 1, 0.66, 0);
            calculation = new Calculation(matirial, tool, handling, 4, 1, 95, 100);

            commandPlus = new Command(ChangeVeiw);
            commandNewValue = new Command(NewValue);

            materials = new ObservableCollection<Material>(Serialization<Material>.Deserialization());
            tools = new ObservableCollection<Tool>(Serialization<Tool>.Deserialization());
            handlings = new ObservableCollection<Handling>(Serialization<Handling>.Deserialization());

            //System.Windows.Forms.MessageBox.Show(System.Windows.SystemParameters.PrimaryScreenWidth.ToString());
            panelOutlet.Left = (-System.Windows.SystemParameters.PrimaryScreenWidth / 3.2) / 3;

        }
        #endregion ctor
        #region Metods
        /// <summary>
        /// В случае необходимости изменения ширины выезжающей панели см. сюда
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        public void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (sender is Window)
            {
                //В случае необходимости изменения ширины выезжающей панели см. сюда
                Window window = (Window)sender;
                if (window.WindowState == WindowState.Maximized)
                    panelOutlet.Left = -System.Windows.SystemParameters.PrimaryScreenWidth / 3 + 35;
                else
                    panelOutlet.Left = -window.Width / 3 + 35;
                //В случае необходимости изменения ширины выезжающей панели см. сюда
                PanelOutlet = panelOutlet;
            }
        }

        public void OnWindowClosing(object sender, EventArgs e)
        {
            Serialization<Material>.Save(materials);
            Serialization<Tool>.Save(tools);
            Serialization<Handling>.Save(handlings);
        }
        #endregion Metods
        #region Command
        public ICommand ChangeViewCommand
        {
            get { return commandPlus; }
        }
        public ICommand AddNewValueSpindleSpeed
        {
            get { return commandNewValue; }
        }
        #endregion Command
        #region Properties
        public string CuttingSpeed
        {
            get { return "V = " + calculation.CuttingSpeed_V.ToString() + " м/мин"; }
        }
        public string SpindleSpeed
        {
            get { return "n = " + calculation.SpindleSpeed_N.ToString() + " об/мин"; }
            //set
            //{
            //    try
            //    {
            //        calculation.SpindleSpeed_N = Convert.ToDouble(value);
            //        UpdateAnswerAllPropertiesChanged();
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Windows.Forms.MessageBox.Show(ex.Message);
            //    }
            //}
        }
        public double SpindleSpeedReal { get; set; }// { return spindleSpeed; } set { spindleSpeed = value; } }
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
            get { return calculation.T_DepthOfCut; }
            set
            {
                calculation.T_DepthOfCut = value;
                UpdateAnswerAllPropertiesChanged();
            }
        }
        public double S_Innings
        {
            get { return calculation.S_Innings; }
            set
            {
                calculation.S_Innings = value;
                UpdateAnswerAllPropertiesChanged();
            }
        }
        public double L_LengthOfTheSurfaceToBeTreated
        {
            get { return calculation.L_LengthOfTheSurfaceToBeTreated; }
            set
            {
                calculation.L_LengthOfTheSurfaceToBeTreated = value;
                UpdateAnswerAllPropertiesChanged();
            }
        }
        public double D_BilletDiameter
        {
            get { return calculation.D_BilletDiameter; }
            set
            {
                calculation.D_BilletDiameter = value;
                UpdateAnswerAllPropertiesChanged();
            }
        }

        public ObservableCollection<Material> Materials
        {
            get { return materials; }
            set { materials = value; }
        }
        public ObservableCollection<Tool> Tools { get { return tools; } set { tools = value; } }
        public ObservableCollection<Handling> Handlings { get { return handlings; } set { handlings = value; } }

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

        // public double PanelOutlet { get => panelOutlet; set => panelOutlet = value; }
        //public Thickness PanelOutlet {
        //    get => new Thickness(-panelOutlet,0,0,0);  }
        public Thickness PanelOutlet
        {
            get => panelOutlet;
            set
            {
                panelOutlet = value;
                OnPropertyChanged("PanelOutlet");
            }
        }
        #endregion Properties
        #endregion Public
    }
}
