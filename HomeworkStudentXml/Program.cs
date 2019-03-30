using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HomeworkStudentXml
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToXml = "StudentsList.xml";

            XmlTextWriter textWriter = new XmlTextWriter(pathToXml, Encoding.UTF8);
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("ArrayOfStudent");
            textWriter.WriteEndElement();
            textWriter.Close();

            XmlDocument document = new XmlDocument();
            document.Load(pathToXml);

            XmlNode element = document.CreateElement("student");
            document.DocumentElement.AppendChild(element);
            XmlAttribute attribute = document.CreateAttribute("number");
            attribute.Value = Convert.ToString(1);
            element.Attributes.Append(attribute);

            XmlNode subElement1 = document.CreateElement("fullName");
            subElement1.InnerText = "Патрик Кейн";
            element.AppendChild(subElement1);

            XmlNode subElement2 = document.CreateElement("homeland");
            subElement2.InnerText = "Chicago";
            element.AppendChild(subElement2);

            XmlNode subElement3 = document.CreateElement("birthYear");
            subElement3.InnerText = "1989";
            element.AppendChild(subElement3);

            document.Save(pathToXml);

            List<Student> students = new List<Student>();

            XmlSerializer formatter = new XmlSerializer(typeof(List<Student>));
            using (FileStream stream = new FileStream(pathToXml, FileMode.OpenOrCreate))
            {
                students = (List<Student>)formatter.Deserialize(stream);
                Console.WriteLine("Успешно!");
            }

            Console.ReadLine();
        }
    }
}
