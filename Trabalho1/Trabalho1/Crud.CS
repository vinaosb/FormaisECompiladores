using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Xml.Serialization;

namespace Trabalho1
{
    public class Crud
    {
        private string Path;
        Crud(string P)
        {
            Path = P;
        }

        public void Store<T> (T c)
        {
            Stream stream = File.OpenWrite(Environment.CurrentDirectory + Path);

            XmlSerializer xmlSer = new XmlSerializer(typeof(T));

            xmlSer.Serialize(stream, c);

            stream.Close();
        }

        public void Load<T> (T c)
        {
            Stream stream = File.OpenRead(Environment.CurrentDirectory + Path);

            XmlSerializer xmlSer = new XmlSerializer(typeof(T));

            xmlSer.Deserialize(stream);

            stream.Close();
        }
    }
}
