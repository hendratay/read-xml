using System;
using System.IO;
using System.Xml;

namespace ReadXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "DummyData.xml";
            FileStream levelFile = File.Open(path, FileMode.Open);
            XmlDocument xmlDoc = new XmlDocument();

            string xmlText = "";
            using (StreamReader sr = new StreamReader(levelFile))
            {
                string line = null;
                do
                {
                    line = sr.ReadLine();
                    xmlText = xmlText + line + "\n";
                } while (line != null);
                sr.Close();
                levelFile.Close();
            }
            xmlDoc.LoadXml(xmlText);

            // Get string Value
            Console.WriteLine("name: " + xmlDoc.SelectSingleNode("//string[@name='name']").InnerText);
            Console.WriteLine("desc: " + xmlDoc.SelectSingleNode("//string[@name='description']").InnerText);
            // Get int Value
            Console.WriteLine("price: " + xmlDoc.SelectSingleNode("//int[@name='price']").Attributes["value"].Value);
        }
    }
}
