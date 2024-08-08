using System.IO;
using System.Xml.Serialization;

namespace SiriusGahca
{
    public class Case
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("img")]
        public string IconPerson { get; set; }
        [XmlAttribute("tag")]
        public string Tag { get; set; }

        public static List<Case> Deserialize(string path)
        {
            XmlSerializer deserialize = new XmlSerializer(typeof(List<Case>));
            using (FileStream reader = new FileStream(path, FileMode.OpenOrCreate))
            {
                return deserialize.Deserialize(reader) as List<Case> ?? throw new Exception();
            }
        }
    }
}