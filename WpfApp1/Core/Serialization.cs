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
        static public void Save(IEnumerable<T> ColectionList)
        {
            XmlSerializer formatter = null;
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
                if (formatter != null)
                {
                    formatter.Serialize(fs, ColectionList.ToList());
                }
            }
        }

        static public List<T> Deserialization()
        {
            XmlSerializer formatter = null;
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
                    if (formatter != null)
                    {
                        temp = (List<T>)formatter.Deserialize(fs);
                    }

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
