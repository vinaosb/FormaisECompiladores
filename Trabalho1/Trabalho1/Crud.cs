/*
 * Universidade Federal de Santa Catarina
 * Departamento de Informática e Estatística
 * Marcelo José Dias, Thiago Martendal Salvador, Vinícius Schwinden Berkenbrock
 */

using System;
using System.IO;
using System.Xml.Serialization;

namespace Trabalho1
{
    public class Crud
    {
        // Caminho para o arquivo
        private string Path;
        public Crud(string P)
        {
            Path = "/" + P + ".xml";
        }

        // Cria arquivo .xml para salvar a lista de classe T
        public void Store<T>(T c)
        {
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }

            using (Stream stream = File.OpenWrite(Environment.CurrentDirectory + Path))
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(T));

                xmlSer.Serialize(stream, c);
            }
        }


        // Carrega arquivo .xml para carregar lista de classe T
        public void Load<T>(T c)
        {
            using (Stream stream = File.OpenRead(Environment.CurrentDirectory + Path))
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(T));

                xmlSer.Deserialize(stream);
            }
        }
    }
}
