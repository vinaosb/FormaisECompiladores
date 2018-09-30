using System;
using System.IO;
using System.Xml.Serialization;

namespace Trabalho1
{
    public class Crud
    {
        private string Path;
        public Crud(string P)
        {
            if (Environment.OSVersion.Platform.Equals(PlatformID.Unix))
                Path = "/" + P + ".xml";
            else
                Path = "\\" + P + ".xml";
        }

        public void Store<T>(T c)
        {
            using (Stream stream = File.Create(Environment.CurrentDirectory + Path))
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(T));

                xmlSer.Serialize(stream, c);
            }
        }

        public void Load<T>(ref T c)
        {
            using (Stream stream = File.OpenRead(Environment.CurrentDirectory + Path))
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(T));

                c = (T)xmlSer.Deserialize(stream);
            }
        }
    }
}
