using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeworkHabraHabr
{
    [Serializable]
    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "link")]
        public string Link { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "pubdate")]
        public DateTime PubDate { get; set; }
        public Item()
        {

        }
    }
}
/*1.	Прочитать содержимое XML файла со списком последних новостей по ссылке https://habrahabr.ru/rss/interesting/
Создать класс Item со свойствами: Title, Link, Description, PubDate.
Создать коллекцию типа List<Item> и записать в нее данные из файла.
*/
