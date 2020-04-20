using Exercicio1Aula12.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Exercicio1Aula12.Utils
{
    public class ManipuladorXML
    {
        public static object DeserializationXML<T>(string rootElement)
        {
            object input = null;
            try
            {
                XmlRootAttribute root = new XmlRootAttribute(rootElement);
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>), root);
                StreamReader reader = new StreamReader(CarregarXML.LoadXML());

                input = serializer.Deserialize(reader);
                reader.Close();    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            return input;
            
        }
        public static void SerializationXML<T>( List<T> obj)
        {
            XmlDocument document = new XmlDocument();
            try
            {                
                document.Load(CarregarXML.LoadXML());
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                StreamWriter writer = new StreamWriter(CarregarXML.LoadXML());
                
                
                serializer.Serialize(writer, obj);
                writer.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
               
        }
    }
}
