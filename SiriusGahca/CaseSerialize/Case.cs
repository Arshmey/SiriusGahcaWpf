using System.Xml.Serialization;

namespace SiriusGahca.CaseSerialize
{
    public class Case
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("img")]
        public string IconPerson { get; set; }
        [XmlAttribute("tag")]
        public string Tag { get; set; }
    }
}
