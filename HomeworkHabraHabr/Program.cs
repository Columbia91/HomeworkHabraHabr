using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;

namespace HomeworkHabraHabr
{
    class Program
    {
        static void Main(string[] args)
        {
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

            XmlNodeList items = doc.SelectNodes("rss/channel/item");
            XmlNodeList titles = doc.SelectNodes("rss/channel/item/title");
            XmlNodeList links = doc.SelectNodes("rss/channel/item/link");
            XmlNodeList descriptions = doc.SelectNodes("rss/channel/item/description");
            XmlNodeList pubDates = doc.SelectNodes("rss/channel/item/pubDate");

            List<Item> list = new List<Item>();
            for (int i = 0; i < items.Count; i++)
            {
                Item item = new Item();
                item.Title = titles[i].InnerText;
                item.Link = links[i].InnerText;
                item.Description = descriptions[i].InnerText;
                item.PubDate = DateTime.Parse(pubDates[i].InnerText);
                list.Add(item);
            }
        }
    }
}