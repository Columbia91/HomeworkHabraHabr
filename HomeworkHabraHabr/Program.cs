using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HomeworkHabraHabr
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> list = new List<Item>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Item>));

            string url = "https://habrahabr.ru/rss/interesting/";
            string xml;
            using (WebClient client = new WebClient())
            {
                xml = client.DownloadString(url);
            }

            using (StreamWriter writer = new StreamWriter("file.xml", false, System.Text.Encoding.Default))
            {
                writer.Write(xml);
            }

            XmlDocument doc = new XmlDocument();
            doc.Load("file.xml");
            XmlNodeList items = doc.SelectNodes("rss/channel/item/title");

            Console.WriteLine(items.Count);
        }
    }
}
/*XmlDocument doc = new XmlDocument();
        doc.Load("E:\\Temp\\1.xml");
        XmlNodeList urls = doc.SelectNodes("response/audio/url");
        foreach(XmlNode url in urls)
            Console.WriteLine(url.InnerText);
        Console.ReadKey(true);*/
