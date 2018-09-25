using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Core
{
    class Serialization<T>
    {
        List<T> ColectionList;
        XmlSerializer formatter;
        public Serialization(List<T> list)
        {
            this.ColectionList = list;
            try
            {
            formatter = new XmlSerializer(typeof(List<T>));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        public void Save()
        {
            using (FileStream fs = new FileStream(typeof(T).Name + ".xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, ColectionList);
            }
        }

        public List<T> Deserialization()
        {
            using (FileStream fs = new FileStream(typeof(T).Name + ".xml", FileMode.OpenOrCreate))
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
