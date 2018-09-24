using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Core;
namespace WpfApp1
{
    class AddToolViewModel : ViewModelBase
    {
        private Comand command;
        Action<object> action;

        private string name;
        private double kiv;
        public AddToolViewModel(Action<object> action)
        {
            this.action = action;
            command = new Comand(CreateTool);
        }
        public ICommand AddTool => command;

        public string Name { get => name; set => name = value; }
        public double Kiv { get => kiv; set => kiv = value; }

        private void CreateTool(object NotUse)
        {
            try
            {
                //System.Windows.Forms.MessageBox.Show(name+Kiv);
                action(new Tool(name, kiv));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                //System.Windows.Forms.MessageBox.Show(ex.StackTrace);
            }
        }

    }
}
