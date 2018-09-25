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
            using (FileStream fs = new FileStream(typeof(T).Name + "s.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, ColectionList);
            }
        }

        public List<T> Deserialization()
        {
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

        //static public IEnumerable<T> Deserialization<T>(IEnumerable<T> output)
        //{
        //    XmlSerializer formatter=new XmlSerializer (typeof(int));
        //    try
        //    {
        //        formatter = new XmlSerializer(typeof(IEnumerable<T>));
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }
        //    using (FileStream fs = new FileStream(typeof(T).Name + "s.xml", FileMode.OpenOrCreate))
        //    {
        //        //IEnumerable<T> temp = new List<T>();
        //        try
        //        {
        //           // temp = (IEnumerable<T>)formatter.Deserialize(fs);

        //            output = (IEnumerable<T>)formatter.Deserialize(fs);
        //        }
        //        catch (Exception ex)
        //        {
        //            System.Windows.Forms.MessageBox.Show(ex.Message);
        //        }
        //        //output=new ObservableCollection<T> (temp);
        //        return output;
        //    }
        //}
    }
}
