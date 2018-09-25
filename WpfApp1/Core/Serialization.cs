using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace Core
{
    class Serialization<T>
    {       
        static public void Save(List<T> ColectionList)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(int));
            try
            {
                formatter = new XmlSerializer(typeof(List<T>));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            using (FileStream fs = new FileStream(typeof(T).Name + "s.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, ColectionList);
            }
        }

        static public List<T> Deserialization()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(int));
            try
            {
                formatter = new XmlSerializer(typeof(List<T>));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            using (FileStream fs = new FileStream(typeof(T).Name + "s.xml", FileMode.OpenOrCreate))
            {
                List<T> temp = new List<T>();
                try
                {
                    temp = (List<T>)formatter.Deserialize(fs);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                return temp;
            }
        }      
    }
}
