using System.Xml.Serialization;
using System.IO;

namespace SiriusGahca
{
    public class Person
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("img")]
        public string IconPerson { get; set; }
        [XmlAttribute("rate")]
        public int Rate { get; set; }
        [XmlAttribute("changeMin")]
        public int Min { get; set; }
        [XmlAttribute("changeMax")]
        public int Max { get; set; }

        public static List<Person> Deserialize(string path)
        {
            XmlSerializer deserialize = new XmlSerializer(typeof(List<Person>));
            using (FileStream reader = new FileStream(path, FileMode.OpenOrCreate))
            {
                return deserialize.Deserialize(reader) as List<Person> ?? throw new Exception();
            }
        }
    }
}
