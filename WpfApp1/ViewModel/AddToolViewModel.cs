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
        private Command command;
        Action<object> action;

        private string name;
        private double kiv;
        public AddToolViewModel(Action<object> action)
        {
            this.action = action;
            command = new Command(CreateTool);
        }
        public ICommand AddTool {get { return command;}}

        public string Name { get {return name;} set { name = value;} }
        public double Kiv { get { return kiv; } set { kiv = value; } }

        private void CreateTool(object NotUse)
        {
            try
            {              
                action(new Tool(name, kiv));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);                
            }
        }

    }
}
